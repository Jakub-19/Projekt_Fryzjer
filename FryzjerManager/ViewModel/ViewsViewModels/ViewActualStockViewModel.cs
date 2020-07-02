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
    public class ViewActualStockViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<object> ChangeView;
        private ICommand _sarch = null;
        public ICommand Search
        {
            get
            {
                if (_sarch == null)
                    _sarch = new ViewModelBase.RelayCommand(
                        arg => { 
                            inventory.GetAllProducts(ProductName);
                            inventory.GetAllSingleUseProducts(ProductName);
                            OnPropertyChanged(nameof(Products));
                        },
                        arg => true);
                return _sarch;
            }
        }

        Inventory inventory = new Inventory();
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

    }
}