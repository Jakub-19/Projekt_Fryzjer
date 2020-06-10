using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FryzjerManager.ViewModel
{
    using RelayCommand = ViewModelBase.RelayCommand;
    using V = Views;
    using R = Properties.Resources;

    public class MainWindowViewModel : ViewModelBase.ViewModelBase
    {
        private ICommand _gotoViewMenuWindowCommand;
        private ICommand _gotoViewCustomersCommand;
        private ICommand _gotoViewCustomerAddCommand;
        private ICommand _gotoViewServiceDoneCommand;
        private ICommand _gotoViewMainStockCommand;
        private object _currentView;
        private object _viewMenuWindow;
        private object _viewCustomers;
        private object _viewCustomerAdd;
        private object _viewServiceDone;
        private object _viewMainStock;
        
        public MainWindowViewModel()
        {
            _viewMenuWindow = new V.ViewMenuWindow();
            _viewCustomers = new V.ViewCustomers();
            _viewCustomerAdd = new V.ViewCustomerAdd();
            _viewServiceDone = new V.ViewServiceDone();
            _viewMainStock = new V.ViewMainStock();

            CurrentView = _viewMenuWindow;
        }

        #region ResourcesTextNames
        public string ViewMenuWindowCustomersButtonText{
            get{ return R.ViewMenuWindowCustomersButtonText; }}
        public string ViewMenuWindowServicesButtonText{
            get{ return R.ViewMenuWindowServicesButtonText; }}
        public string ViewMenuWindowStockButtonText{
            get { return R.ViewMenuWindowStockButtonText; }}
        public string ViewMenuWindowAuthorsButtonText{
            get { return R.ViewMenuWindowAuthorsButtonText; }}
        public string ApplicationName{
            get { return R.ApplicationName; }}
        public string ViewCustomersAddCustomerButtonText{
            get { return R.ViewCustomersAddCustomerButtonText; }}
        public string ViewCustomersServicesHistoryButtonText{
            get { return R.ViewCustomersServicesHistoryButtonText; }}
        public string ViewMainStockAddDeliveryButtonText{
            get { return R.ViewMainStockAddDeliveryButtonText; }}
        public string ViewMainStockActualStockButtonText{
            get { return R.ViewMainStockActualStockButtonText; }}
        public string ViewCustomerAddLabelNameContent{
            get { return R.ViewCustomerAddLabelNameContent; }}
        public string ViewCustomerAddLabelSurnameContent{
            get { return R.ViewCustomerAddLabelSurnameContent; }}
        public string ViewCustomerAddLabelPhoneNumberContent{
            get { return R.ViewCustomerAddLabelPhoneNumberContent; }}
        public string ViewCustomerAddConfirmButtonText{
            get { return R.ViewCustomerAddConfirmButtonText; }}
        public string ViewServiceDoneLabelCustomerContent{
            get { return R.ViewServiceDoneLabelCustomerContent; }}
        public string ViewServiceDoneChooseButtonText{ 
            get { return R.ViewServiceDoneChooseButtonText; }}
        #endregion
        public ICommand GotoViewMenuWindowCommand
        {
            get
            {
                return _gotoViewMenuWindowCommand ?? (_gotoViewMenuWindowCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewMenuWindow();
                   }));
            }
        }

        public ICommand GotoViewCustomerAddCommand
        {
            get
            {
                return _gotoViewCustomerAddCommand ?? (_gotoViewCustomerAddCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewCustomerAdd();
                   }));
            }
        }
        public ICommand GotoViewCustomersCommand
        {
            get
            {
                return _gotoViewCustomersCommand ?? (_gotoViewCustomersCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewCustomers();
                   }));
            }
        }
        public ICommand GotoViewServiceDoneCommand
        {
            get
            {
                return _gotoViewServiceDoneCommand ?? (_gotoViewServiceDoneCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewServiceDone();
                   }));
            }
        }
        public ICommand GotoViewMainStockCommand
        {
            get
            {
                return _gotoViewMainStockCommand ?? (_gotoViewMainStockCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewMainStock();
                   }));
            }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        #region GotoView Methods
        private void GotoViewMenuWindow()
        {
            CurrentView = _viewMenuWindow;
        }
        private void GotoViewCustomers()
        {
            CurrentView = _viewCustomers;
        }
        private void GotoViewCustomerAdd()
        {
            CurrentView = _viewCustomerAdd;
        }
        private void GotoViewServiceDone()
        {
            CurrentView = _viewServiceDone;
        }
        private void GotoViewMainStock()
        {
            CurrentView = _viewMainStock;
        }
        #endregion
    }
}
