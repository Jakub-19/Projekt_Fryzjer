using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FryzjerManager.Model;

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
        private ICommand _gotoPreviousViewCommand;
        private object _currentView;
        private object _previousView;
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
        #region ClientRecord
        private ClientRecord clientRecord = new ClientRecord();

        #region AddNew
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhone { get; set; }
        private ICommand _addNewClient;
        public ICommand AddNewClient
        {
            get
            {
                return _addNewClient ?? (_addNewClient = new RelayCommand(
                   x =>
                   {
                       clientRecord.AddNew(ClientName, ClientSurname, ClientPhone);
                       ClientName = "";
                       ClientSurname = "";
                       ClientPhone = "";
                       OnPropertyChanged(nameof(ClientName));
                       OnPropertyChanged(nameof(ClientSurname));
                       OnPropertyChanged(nameof(ClientPhone));
                       //Informacja zwrotna przydalaby sie
                       GotoPreviousView();
                   }));
            }
        }
        #endregion

        #endregion
        #region VisitRecord
        private ServiceRecord serviceRecord = new ServiceRecord();
        public ObservableCollection<string> Services
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                foreach (var v in serviceRecord.Services)
                    list.Add(v.Name);

                return list;
            }
            set {}
        }
        public ObservableCollection<string> SingleUseProducts
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                for(int i = 0; i < 10; i++)
                    list.Add("Produkt" + i);

                return list;
            }
            set { }
        }
        public ObservableCollection<string> Products
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                for (int i = 0; i < 15; i++)
                    list.Add("Produkt" + i);

                return list;
            }
            set { }
        }
        public ObservableCollection<string> Clients
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                for (int i = 0; i < 10; i++)
                    list.Add("Krzysztof" + i);

                return list;
            }
            set { }
        }
        #endregion
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
        public string ListViewWithCheckboxesSelectAllCheckboxContent{
            get { return R.ListViewWithCheckboxesSelectAllCheckboxContent; }}
        public string CustomersViewName{
            get { return R.CustomersViewName; }}
        public string CustomerAddViewName{
            get { return R.CustomerAddViewName; }}
        public string ServiceDoneViewName{
            get { return R.ServiceDoneViewName; }}
        public string MainStockViewName{
            get { return R.MainStockViewName; }}
        public string ViewServiceDoneAcceptButtonText{
            get { return R.ViewServiceDoneAcceptButtonText; }}
        public string ViewServiceDoneDoneServicesLabelContent{
            get { return R.ViewServiceDoneDoneServicesLabelContent; }}
        public string ViewServiceDoneUsedProductsMultiTextBlockText{
            get { return R.ViewServiceDoneUsedProductsMultiTextBlockText; }}
        public string ViewServiceDoneUsedProductsSingleTextBlockText{
            get { return R.ViewServiceDoneUsedProductsSingleTextBlockText; }}
        public string ViewServiceDoneNameLabelContent{
            get { return R.ViewServiceDoneNameLabelContent; }}
        public string ViewServiceDoneAmountLabelContent{
            get { return R.ViewServiceDoneAmountLabelContent; }}
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
        public ICommand GoBackCommand
        {
            get
            {
                return _gotoPreviousViewCommand ?? (_gotoPreviousViewCommand = new RelayCommand(
                   x =>
                   {
                       GotoPreviousView();
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
        private void GotoPreviousView()
        {
            CurrentView = _previousView;
            _previousView = _viewMenuWindow;
        }
        private void GotoViewMenuWindow()
        {
            _previousView = CurrentView;
            CurrentView = _viewMenuWindow;
        }
        private void GotoViewCustomers()
        {
            _previousView = CurrentView;
            CurrentView = _viewCustomers;
        }
        private void GotoViewCustomerAdd()
        {
            _previousView = CurrentView;
            CurrentView = _viewCustomerAdd;
        }
        private void GotoViewServiceDone()
        {
            _previousView = CurrentView;
            CurrentView = _viewServiceDone;
        }
        private void GotoViewMainStock()
        {
            _previousView = CurrentView;
            CurrentView = _viewMainStock;
        }
        #endregion
    }
}
