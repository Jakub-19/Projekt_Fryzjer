using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FryzjerManager.Model;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    //VM listy produktów w magazynie
    public class ViewActualStockViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<object> ChangeView;
        private ICommand _search = null;
        public ICommand Search
        {
            get
            {
                if (_search == null)
                    _search = new ViewModelBase.RelayCommand(
                        arg => { 
                            inventory.GetAllProducts(ProductName);
                            inventory.GetAllSingleUseProducts(ProductName);
                            OnPropertyChanged(nameof(Products));
                        },
                        arg => true);
                return _search;
            }
        }

        //Dostęp do listy produktów
        Inventory inventory = new Inventory();
        //Obsługa pola i listy Formularza
        public string ProductName { get; set; }
        public ObservableCollection<SingleUseProduct> Products
        {
            get
            {
                ObservableCollection<SingleUseProduct> list = new ObservableCollection<SingleUseProduct>();
                foreach (var v in inventory.SingleUseProducts)
                    list.Add(v);
                foreach (var v in inventory.Products)
                    list.Add(v);

                return list;
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
                        arg => { ChangeView?.Invoke("ViewMenuWindow"); Clear(); },
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
                            Clear();
                            GoBackAction.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }

        private void Clear()
        {
            ProductName = "";
            inventory.Clear();
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(ProductName));
        }
    }
}