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
        private ICommand _gotoViewCustomerSearchCommand;
        private ICommand _gotoViewServicesHistoryCommand;
        private ICommand _gotoViewActualStockCommand;
        private ICommand _gotoViewAuthorsCommand;
        private ICommand _gotoViewProductSearchCommand;
        private object _currentView;
        private object _previousView;
        private object _viewMenuWindow;
        private object _viewCustomers;
        private object _viewCustomerAdd;
        private object _viewCustomerSearch;
        private object _viewServiceDone;
        private object _viewMainStock;
        private object _viewProductSearch;
        private object _viewServicesHistory;
        private object _viewActualStock;
        private object _viewAuthors;

        public MainWindowViewModel()
        {
            _viewMenuWindow = new V.ViewMenuWindow();
            _viewCustomers = new V.ViewCustomers();
            _viewCustomerAdd = new V.ViewCustomerAdd();
            _viewServiceDone = new V.ViewServiceDone();
            _viewMainStock = new V.ViewMainStock();
            _viewCustomerSearch = new V.ViewCustomerSearch();
            _viewProductSearch = new V.ViewProductSearch();
            _viewServicesHistory = new V.ViewServicesHistory();
            _viewActualStock = new V.ViewActualStock();
            _viewAuthors = new V.ViewAuthors();

            CurrentView = _viewMenuWindow;
        }
        #region ClientRecord
        private ClientRecord clientRecord = new ClientRecord();
        public ObservableCollection<Client> Clients
        {
            get
            {
                ObservableCollection<Client> list = new ObservableCollection<Client>();
                foreach (var v in clientRecord.Clients)
                    list.Add(v);

                return list;
            }
            set { }
        }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhone { get; set; }
        public Client CurrentClient { get; set; }
        private void ClientDataClear()
        {
            ClientName = "";
            ClientSurname = "";
            ClientPhone = "";
            CurrentClient = null;
        }
        #region Search
        private ICommand _searchClient;
        public ICommand SearchClient
        {
            get
            {
                return _searchClient ?? (_searchClient = new RelayCommand(
                   x =>
                   {
                       clientRecord.GetClients(ClientName, ClientSurname);
                       OnPropertyChanged(nameof(Clients));
                   }));
            }
        }
        private ICommand _selectClient;
        public ICommand SelectClient
        {
            get
            {
                return _selectClient ?? (_selectClient = new RelayCommand(
                   x =>
                   {
                       ClientName = CurrentClient.Name;
                       ClientSurname = CurrentClient.LastName;
                       ClientPhone = CurrentClient.PhoneNumber;
                       GotoViewServiceDone();
                   },
                   x=>
                   {
                       return CurrentClient != null;
                   }
                   ));
            }
        }
        #endregion

        #region AddNew
        private ICommand _addNewClient;
        public ICommand AddNewClient
        {
            get
            {
                return _addNewClient ?? (_addNewClient = new RelayCommand(
                   x =>
                   {
                       clientRecord.AddNew(ClientName, ClientSurname, ClientPhone);
                       //ClientName = "";
                       //ClientSurname = "";
                       //ClientPhone = "";
                       ClientDataClear();
                       OnPropertyChanged(nameof(ClientName));
                       OnPropertyChanged(nameof(ClientSurname));
                       OnPropertyChanged(nameof(ClientPhone));
                       //Informacja zwrotna przydalaby sie
                       GotoPreviousView();
                   },
                   x =>
                   {
                       return !string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(ClientSurname) && !string.IsNullOrEmpty(ClientPhone);
                   }));
            }
        }
        #endregion

        #endregion
        #region Inventory
        Inventory inventory = new Inventory();
        private List<SingleUseProduct> usedSingleUseProducts = new List<SingleUseProduct>();
        private List<Product> usedProducts = new List<Product>();
        private List<SingleUseProduct> _allProductsRecord;
        private void InventoryDataVlear()
        {
            ProductName = "";
        }
        public ObservableCollection<SingleUseProduct> AllProductsRecord
        {
            get
            {
                ObservableCollection<SingleUseProduct> list = new ObservableCollection<SingleUseProduct>();
                foreach (SingleUseProduct v in _allProductsRecord)
                    list.Add(v);

                return list;
            }
            set 
            {
            }
        }
        public ObservableCollection<string> SingleUseProducts
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                foreach (var v in usedSingleUseProducts)
                    list.Add(v.Name);

                return list;
            }
            set { }
        }
        public ObservableCollection<string> Products
        {
            get
            {
                ObservableCollection<string> list = new ObservableCollection<string>();
                foreach (var v in usedProducts)
                    list.Add(v.Name);

                return list;
            }
            set { }
        }
        private ICommand _singleUseProductPlusButton;
        public ICommand SingleUseProductPlusButton
        {
            get
            {
                return _singleUseProductPlusButton ?? (_singleUseProductPlusButton = new RelayCommand(
                   x =>
                   {
                       _allProductsRecord = inventory.SingleUseProducts;
                       GotoViewProductSearch();
                   }));
            }
        }
        private ICommand _productPlusButton;
        public ICommand ProductPlusButton
        {
            get
            {
                return _productPlusButton ?? (_productPlusButton = new RelayCommand(
                   x =>
                   {
                       _allProductsRecord = new List<SingleUseProduct>();
                       foreach (var v in inventory.Products)
                           _allProductsRecord.Add(v as SingleUseProduct);
                       GotoViewProductSearch();
                   }));
            }
        }
        public string ProductName{get;set;}
        private ICommand _searchProduct;
        public ICommand SearchProduct
        {
            get
            {
                return _searchProduct ?? (_searchProduct = new RelayCommand(
                   x =>
                   {
                       inventory.GetProducts(ProductName);
                       OnPropertyChanged(nameof(AllProductsRecord));
                   }));
            }
        }
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
        #region ICommands by Krzysztof
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
        public ICommand GotoViewServicesHistoryCommand
        {
            get
            {
                return _gotoViewServicesHistoryCommand ?? (_gotoViewServicesHistoryCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewServicesHistory();
                   }));
            }
        }
        public ICommand GotoViewActualStockCommand
        {
            get
            {
                return _gotoViewActualStockCommand ?? (_gotoViewActualStockCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewActualStock();
                   }));
            }
        }
        public ICommand GotoViewAuthorsCommand
        {
            get
            {
                return _gotoViewAuthorsCommand ?? (_gotoViewAuthorsCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewAuthors();
                   }));
            }
        }
        public ICommand GotoViewCustomerSearchCommand
        {
            get
            {
                return _gotoViewCustomerSearchCommand ?? (_gotoViewCustomerSearchCommand = new RelayCommand(
                   x =>
                   {
                       GotoViewCustomerSearch();
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
        #endregion
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
        private void GotoViewCustomerSearch()
        {
            ClientDataClear();
            _previousView = CurrentView;
            CurrentView = _viewCustomerSearch;
        }
        private void GotoViewProductSearch()
        {
            _previousView = CurrentView;
            CurrentView = _viewProductSearch;
        }
        private void GotoViewCustomerAdd()
        {
            ClientDataClear();
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
        private void GotoViewServicesHistory()
        {
            _previousView = CurrentView;
            CurrentView = _viewServicesHistory;
        }
        private void GotoViewActualStock()
        {
            _previousView = CurrentView;
            CurrentView = _viewActualStock;
        }
        private void GotoViewAuthors()
        {
            _previousView = CurrentView;
            CurrentView = _viewAuthors;
        }
        #endregion
    }
}
