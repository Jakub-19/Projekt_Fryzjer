using System;
using System.Collections.Generic;
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
        private object _currentView;
        private object _viewMenuWindow;
        private object _viewCustomers;
        private object _viewCustomerAdd;
        private object _viewServiceDone;

        public MainWindowViewModel()
        {
            _viewMenuWindow = new V.ViewMenuWindow();
            _viewCustomers = new V.ViewCustomers();
            _viewCustomerAdd = new V.ViewCustomerAdd();
            _viewServiceDone = new V.ViewServiceDone();

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
        public ICommand GotoView3Command
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
        #endregion
    }
}
