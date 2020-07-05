using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Collections.ObjectModel;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    using V = Views;
    //VM wprowadzania dostawy towaru
    public class ViewDeliveryAddViewModel : ViewModelBase.ViewModelBase
    {
        #region Formularze
        //Produkty wielorazowe
        private V.ViewProductSearch _viewProductSearch1 = null;
        public V.ViewProductSearch ViewProductSearch1
        {
            get { return _viewProductSearch1; }
            set
            {
                _viewProductSearch1 = value;
                OnPropertyChanged(nameof(ViewProductSearch1));
            }
        }
        private ViewProductSearchViewModel _viewProductSearchViewModel1;
        public ViewProductSearchViewModel ViewProductSearchViewModel1
        {
            get { return _viewProductSearchViewModel1; }
            set
            {
                _viewProductSearchViewModel1 = value;
                ViewProductSearchViewModel1.IsSingleUsed = false;
                ViewProductSearchViewModel1.TransferData += GetProduct;
                ViewProductSearchViewModel1.GoHomeAction += GotoMainMenuFunc;
                OnPropertyChanged(nameof(ViewProductSearchViewModel1));
            }
        }
        //Produkty jednorazowe
        private V.ViewProductSearch _viewProductSearch2 = null;
        public V.ViewProductSearch ViewProductSearch2
        {
            get { return _viewProductSearch2; }
            set
            {
                _viewProductSearch2 = value;
                OnPropertyChanged(nameof(ViewProductSearch2));
            }
        }
        private ViewProductSearchViewModel _viewProductSearchViewModel2;
        public ViewProductSearchViewModel ViewProductSearchViewModel2
        {
            get { return _viewProductSearchViewModel2; }
            set
            {
                _viewProductSearchViewModel2 = value;
                ViewProductSearchViewModel2.IsSingleUsed = true;
                ViewProductSearchViewModel2.TransferData += GetSingleUseProduct;
                ViewProductSearchViewModel2.GoHomeAction += GotoMainMenuFunc;
                OnPropertyChanged(nameof(ViewProductSearchViewModel2));
            }
        }

        //Nowe (nieistniejące w bazie) produkty
        private V.ViewNewProductAdd _viewNewProductAdd = null;
        public V.ViewNewProductAdd ViewNewProductAdd
        {
            get { return _viewNewProductAdd; }
            set
            {
                _viewNewProductAdd = value;
                OnPropertyChanged(nameof(ViewNewProductAdd));
            }
        }
        private ViewNewProductAddViewModel _viewNewProductAddViewModel;
        public ViewNewProductAddViewModel ViewNewProductAddViewModel
        {
            get { return _viewNewProductAddViewModel; }
            set
            {
                _viewNewProductAddViewModel = value;
                ViewNewProductAddViewModel.TransferData += GetNewProduct;
                ViewNewProductAddViewModel.GoHomeAction += GotoMainMenuFunc;
                OnPropertyChanged(nameof(ViewNewProductAddViewModel));
            }
        }
        #endregion

        public event Action<object, bool> ChangeView;
        //Nawigacja do podformularzy
        private ICommand _selectProduct = null;
        public ICommand SelectProduct
        {
            get
            {
                if (_selectProduct == null)
                    _selectProduct = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewProductSearch1, true); },
                        arg => true);
                return _selectProduct;
            }
        }

        private ICommand _selectSingleUseProduct = null;
        public ICommand SelectSingleUseProduct
        {
            get
            {
                if (_selectSingleUseProduct == null)
                    _selectSingleUseProduct = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewProductSearch2, true); },
                        arg => true);
                return _selectSingleUseProduct;
            }
        }

        private ICommand _addNewProduct = null;
        public ICommand AddNewProduct
        {
            get
            {
                if (_addNewProduct == null)
                    _addNewProduct = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewNewProductAdd, true); },
                        arg => true);
                return _addNewProduct;
            }
        }
        //Komunikacja podformularzy z tym formularzem (przekaz danych)
        private void GetProduct(SingleUseProduct product)
        {
            Products.Add(product as Product);
            OnPropertyChanged(nameof(Products));
            ChangeView?.Invoke("ViewDeliveryAdd", false);
        }
        private void GetSingleUseProduct(SingleUseProduct product)
        {
            SingleUseProducts.Add(product);
            OnPropertyChanged(nameof(SingleUseProducts));
            ChangeView?.Invoke("ViewDeliveryAdd", false);
        }
        private void GetNewProduct(object product)
        {
            NewProducts.Add(product as SingleUseProduct);
            OnPropertyChanged(nameof(NewProducts));
            ChangeView?.Invoke("ViewDeliveryAdd", false);
        }
        //Obsługa formularza
        //Dodane produkty
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<SingleUseProduct> SingleUseProducts { get; set; } = new ObservableCollection<SingleUseProduct>();
        public ObservableCollection<SingleUseProduct> NewProducts { get; set; } = new ObservableCollection<SingleUseProduct>();
        private Inventory inventory = new Inventory();//Komunikacja z magazynem

        private ICommand _confirmDelivery = null;
        public ICommand ConfirmDelivery
        {
            get
            {
                if (_confirmDelivery == null)
                    _confirmDelivery = new ViewModelBase.RelayCommand(
                        arg =>
                        {
                            //Przesył danych do BD
                            foreach (var v in Products)
                                inventory.Add(v, (uint)(v.Count + v.SuggestedConsumption));
                            foreach (var v in SingleUseProducts)
                                inventory.Add(v, (uint)(v.Count + v.SuggestedConsumption));
                            foreach (var v in NewProducts)
                            {
                                if(v is Product)
                                    inventory.AddNew(v as Product);
                                else
                                    inventory.AddNew(v);
                            }
                            Clear();
                            ChangeView?.Invoke("ViewMainStock", false);
                        },
                        arg => Products.Count > 0 || SingleUseProducts.Count > 0 || NewProducts.Count > 0);
                return _confirmDelivery;
            }
        }

        //Nawigacja
        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { GotoMainMenuFunc(); },
                        arg => true);
                return _gotoMainMenu;
            }
        }
        private void GotoMainMenuFunc()
        {
            ChangeView?.Invoke("ViewMenuWindow", false);
            Clear();
        }

        public event Action GoBackAction;
        private ICommand _goBack = null;
        public ICommand GoBack
        {
            get
            {
                if (_goBack == null)
                    _goBack = new ViewModelBase.RelayCommand(
                        arg => {
                            Clear();
                            GoBackAction.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }

        private void Clear()
        {
            Products = new ObservableCollection<Product>();
            SingleUseProducts = new ObservableCollection<SingleUseProduct>();
            NewProducts = new ObservableCollection<SingleUseProduct>();
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(SingleUseProducts)); ;
            OnPropertyChanged(nameof(NewProducts));
            inventory.Clear();
            ViewNewProductAddViewModel.Clear();
            ViewProductSearchViewModel1.Clear();
            ViewProductSearchViewModel2.Clear();
        }
    }
}
