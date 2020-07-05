using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Security.Policy;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    //VM formularza umożliwiającego dodanie nowego (nieistniejącego w bazie) produktu
    public class ViewNewProductAddViewModel : ViewModelBase.ViewModelBase
    {
        #region Komendy przyciskow
        public event Action<object> TransferData;//Przekazuje dane formularzowi-rodzicowi
        private ICommand _addProduct = null;
        public ICommand AddProduct
        {
            get
            {
                if (_addProduct == null)
                    _addProduct = new ViewModelBase.RelayCommand(
                        arg => {
                            object product;
                            if (IsSingleUse)
                                product = new SingleUseProduct(0, ProductName, 0, int.Parse(ProductPrice));
                            else
                                product = new Product(0, ProductName, 0, 0, int.Parse(ProductCapacity), int.Parse(ProductPrice));
                            TransferData?.Invoke(product);
                            Clear();
                        },
                        arg => (!string.IsNullOrEmpty(ProductName) && !string.IsNullOrEmpty(ProductPrice)) && 
                            (IsSingleUse || (!string.IsNullOrEmpty(ProductCapacity) && int.TryParse(ProductCapacity, out int x))) && int.TryParse(ProductPrice, out int z));
                return _addProduct;
            }
        }
        #endregion

        //Obsługa formularza
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCapacity { get; set; }
        public bool IsSingleUse { get; set; } = true;

        //Nawigacja
        public event Action GoHomeAction;
        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { GoHomeAction?.Invoke(); },
                        arg => true);
                return _gotoMainMenu;
            }
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
                            GoBackAction?.Invoke();
                            Clear();
                        }, arg => true);
                return _goBack;
            }
        }

        public void Clear()
        {
            ProductName = "";
            ProductPrice = "";
            ProductCapacity = "";
            OnPropertyChanged(nameof(ProductName));
            OnPropertyChanged(nameof(ProductPrice));
            OnPropertyChanged(nameof(ProductCapacity));
        }
    }
}
