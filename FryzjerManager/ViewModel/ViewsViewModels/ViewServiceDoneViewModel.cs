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

    //VM dodawania ukończonej wizyty
    public class ViewServiceDoneViewModel : ViewModelBase.ViewModelBase
    {
        #region Formularze
        //Wybór klienta
        private V.ViewCustomerSearch _viewCustomerSearch = null;
        public V.ViewCustomerSearch ViewCustomerSearch
        {
            get { return _viewCustomerSearch; }
            set
            {
                _viewCustomerSearch = value;
                OnPropertyChanged(nameof(ViewCustomerSearch));
            }
        }
        private ViewCustomerSearchViewModel _viewCustomerSearchViewModel;
        public ViewCustomerSearchViewModel ViewCustomerSearchViewModel
        {
            get { return _viewCustomerSearchViewModel; }
            set
            {
                _viewCustomerSearchViewModel = value;
                ViewCustomerSearchViewModel.TransferData += GetClient;
                ViewCustomerSearchViewModel.GoHomeAction += GotoMainMenuFunc;
                OnPropertyChanged(nameof(ViewCustomerSearchViewModel));
            }
        }

        //Wybór produktów wielorazowych
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

        //Wybór produktów jednorazowych
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
        #endregion

        public event Action<object, bool> ChangeView;

        //Wybór klienta (komenda pokazująca widok)
        private ICommand _selectCustomer = null;
        public ICommand SelectCustomer
        {
            get
            {
                if (_selectCustomer == null)
                    _selectCustomer = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewCustomerSearch, true); },
                        arg => true);
                return _selectCustomer;
            }
        }

        //Wybór produktów (komenda pokazująca widok)
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

        //Wybór produktów (komenda pokazująca widok)
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

        // Metody umożliwiające przepływ danych pomiędzy podformularzami a głównym formularzem dodawania wizyty
        private void GetClient(Client client)
        {
            CurrentClient = client;
            OnPropertyChanged(nameof(CurrentClient));
            ChangeView?.Invoke("ViewServiceDone", false);

        }
        private void GetProduct(SingleUseProduct product)
        {
            Products.Add(product as Product);
            OnPropertyChanged(nameof(Products));
            ChangeView?.Invoke("ViewServiceDone", false);
        }
        private void GetSingleUseProduct(SingleUseProduct product)
        {
            SingleUseProducts.Add(product);
            OnPropertyChanged(nameof(SingleUseProducts));
            ChangeView?.Invoke("ViewServiceDone", false);
        }

        public Client CurrentClient { get; set; }//Wybrany klient
        private Inventory inventory = new Inventory();//Komunikacja z magazynem
        private ServiceRecord serviceRecord = new ServiceRecord();//Dostępne usługi
        public ObservableCollection<object> Services
        {
            get
            {
                ObservableCollection<object> list = new ObservableCollection<object>();
                foreach (var v in serviceRecord.Services)
                    list.Add(v);

                return list;
            }
        }
        public ObservableCollection<object> ServicesChecked//Wybrane (zaznaczone) usługi
        {
            get;
            set;         
        }
        //Użyte produkty
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<SingleUseProduct> SingleUseProducts { get; set; } = new ObservableCollection<SingleUseProduct>();

        public DateTime VisitDate { get; set; } = DateTime.Now;

        //Zatwierdzenie wizyty
        private ICommand _confirmVisit = null;
        public ICommand ConfirmVisit
        {
            get
            {
                if (_confirmVisit == null)
                    _confirmVisit = new ViewModelBase.RelayCommand(
                        arg => {
                            List<Product> products = new List<Product>();
                            List<SingleUseProduct> sProducts = new List<SingleUseProduct>();
                            double finalPrice = 0;//Cena końcowa obliczana na podstawie zużycia produktów i cen usług
                            //aktualizacja zużycia
                            if (Products != null)
                            {
                                foreach (Product v in Products)
                                {
                                    inventory.UseUp(v, (uint)v.SuggestedConsumption);
                                    products.Add(v);
                                    finalPrice += (v.SuggestedConsumption / v.Capacity) * v.Price;
                                }
                            }
                            if (SingleUseProducts != null)
                            {
                                foreach (SingleUseProduct v in SingleUseProducts)
                                {
                                    inventory.UseUp(v, (uint)v.SuggestedConsumption);
                                    sProducts.Add(v);
                                    finalPrice += v.SuggestedConsumption * v.Price;
                                }
                            }

                            //dodanie wizyty
                            List<Service> services = new List<Service>();
                            foreach (Service v in ServicesChecked)
                            {
                                services.Add(v);
                                finalPrice += v.Price;
                            }

                            VisitRecord visitRecord = new VisitRecord();
                            visitRecord.Add(new Visit(finalPrice, CurrentClient, services, VisitDate), products, sProducts);
                            ChangeView?.Invoke("ViewMenuWindow", false);
                        },
                        arg => ServicesChecked != null && ServicesChecked.Count > 0 && CurrentClient != null);
                return _confirmVisit;
            }
        }

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
                            GoBackAction?.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }
        private void Clear()
        {
            Products = new ObservableCollection<Product>();
            SingleUseProducts = new ObservableCollection<SingleUseProduct>();
            VisitDate = DateTime.Now;
            inventory.Clear();
            CurrentClient = null;
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(CurrentClient)); ;
            OnPropertyChanged(nameof(SingleUseProducts));
            ViewCustomerSearchViewModel.Clear();
            ViewProductSearchViewModel1.Clear(); 
            ViewProductSearchViewModel2.Clear();
        }
    }
}
