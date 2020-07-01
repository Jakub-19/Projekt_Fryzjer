using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    using V = Views;
    public class ViewServiceDoneViewModel : ViewModelBase.ViewModelBase
    {
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
                OnPropertyChanged(nameof(ViewCustomerSearchViewModel));
            }
        }


        //1 to wielorazowe a 2 to jednorazowe
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
                OnPropertyChanged(nameof(ViewProductSearchViewModel1));
            }
        }
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
                OnPropertyChanged(nameof(ViewProductSearchViewModel2));
            }
        }


        public event Action<object> ChangeView;

        private ICommand _selectCustomer = null;
        public ICommand SelectCustomer
        {
            get
            {
                if (_selectCustomer == null)
                    _selectCustomer = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewCustomerSearch); },
                        arg => true);
                return _selectCustomer;
            }
        }


        //Trzeba sobie wybrac o ktore produkty chodzi
        //private ICommand _selectProduct = null;
        //public ICommand SelectProduct
        //{
        //    get
        //    {
        //        if (_selectProduct == null)
        //            _selectProduct = new ViewModelBase.RelayCommand(
        //                arg => { ChangeView?.Invoke(ViewProductSearch); },
        //                arg => true);
        //        return _selectProduct;
        //    }
        //}




        //private ICommand _selectSingleUseProduct = null;
        //public ICommand SelectSingleUseProduct
        //{
        //    get
        //    {
        //        if (_selectSingleUseProduct == null)
        //            _selectSingleUseProduct = new ViewModelBase.RelayCommand(
        //                arg => { ChangeView?.Invoke(ViewProductSearch); },
        //                arg => true);
        //        return _selectSingleUseProduct;
        //    }
        //}
        public Client CurrentClient { get; set; }
    }
}
