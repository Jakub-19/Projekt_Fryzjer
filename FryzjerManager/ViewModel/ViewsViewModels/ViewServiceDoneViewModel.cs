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
    using VM = ViewsViewModels;
    public class ViewServiceDoneViewModel : ViewModelBase.ViewModelBase
    {
        #region formularze wyszuliwania
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
        private VM.ViewCustomerSearchViewModel _viewCustomerSearchViewModel;
        public VM.ViewCustomerSearchViewModel ViewCustomerSearchViewModel
        {
            get { return _viewCustomerSearchViewModel; }
            set
            {
                _viewCustomerSearchViewModel = value;
                ViewCustomerSearchViewModel.TransferData += GetClient;
                OnPropertyChanged(nameof(ViewCustomerSearchViewModel));
            }
        }

        private V.ViewProductSearch _viewProductSearch = null;
        public V.ViewProductSearch ViewProductSearch
        {
            get { return _viewProductSearch; }
            set
            {
                _viewProductSearch = value;
                OnPropertyChanged(nameof(ViewProductSearch));
            }
        }
        private VM.ViewProductSearchViewModel _viewProductSearchViewModel;
        public VM.ViewProductSearchViewModel ViewProductSearchViewModel
        {
            get { return _viewProductSearchViewModel; }
            set
            {
                _viewProductSearchViewModel = value;
                OnPropertyChanged(nameof(ViewProductSearchViewModel));
            }
        }
        #endregion

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
        private ICommand _selectProduct = null;
        public ICommand SelectProduct
        {
            get
            {
                if (_selectProduct == null)
                    _selectProduct = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewProductSearch); },
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
                        arg => { ChangeView?.Invoke(ViewProductSearch); },
                        arg => true);
                return _selectSingleUseProduct;
            }
        }
        private void GetClient(Client client)
        {
            CurrentClient = client;
            OnPropertyChanged(nameof(CurrentClient));
            ChangeView?.Invoke("ViewServiceDone");

        }
        public Client CurrentClient { get; set; }
    }
}
