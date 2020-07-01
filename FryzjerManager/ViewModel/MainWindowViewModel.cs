using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FryzjerManager.Model;
using System.Windows.Controls;
using System.Diagnostics;

namespace FryzjerManager.ViewModel
{
    using RelayCommand = ViewModelBase.RelayCommand;
    using V = Views;
    using VM = ViewsViewModels;
    using R = Properties.Resources;

    public class MainWindowViewModel : ViewModelBase.ViewModelBase
    {
        private UserControl _currentView = null;
        public UserControl CurrentView
        {
            get { return _currentView; }
            set 
            {   _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public Stack<UserControl> _previousViews;
        public Stack<UserControl> PreviousViews
        {
            get =>_previousViews;
        }

        #region Widoki i ich VM'y
        private V.ViewActualStock _viewActualStock = null;
        public V.ViewActualStock ViewActualStock
        {
            get { return _viewActualStock; }
            set
            {
                _viewActualStock = value;
                OnPropertyChanged(nameof(ViewActualStock));
            }
        }
        private VM.ViewActualStockViewModel _vievActualStockViewModel;
        public VM.ViewActualStockViewModel ViewActualStockViewModel
        {
            get { return _vievActualStockViewModel; }
            set 
            { 
                _vievActualStockViewModel = value; 
                OnPropertyChanged(nameof(ViewActualStockViewModel)); 
            }
        }



        private V.ViewAuthors _viewAuthors = null;
        public V.ViewAuthors ViewAuthors
        {
            get { return _viewAuthors; }
            set
            {
                _viewAuthors = value;
                OnPropertyChanged(nameof(ViewAuthors));
            }
        }
        private VM.ViewAuthorsViewModel _viewAuthorsViewModel;
        public VM.ViewAuthorsViewModel ViewAuthorsViewModel
        {
            get { return _viewAuthorsViewModel; }
            set
            {
                _viewAuthorsViewModel = value;
                OnPropertyChanged(nameof(ViewAuthorsViewModel));
            }
        }



        private V.ViewCustomerAdd _viewCustomerAdd = null;
        public V.ViewCustomerAdd ViewCustomerAdd
        {
            get { return _viewCustomerAdd; }
            set
            {
                _viewCustomerAdd = value;
                OnPropertyChanged(nameof(ViewCustomerAdd));
            }
        }
        private VM.ViewCustomerAddViewModel _viewCustomerAddViewModel;
        public VM.ViewCustomerAddViewModel ViewCustomerAddViewModel
        {
            get { return _viewCustomerAddViewModel; }
            set
            {
                _viewCustomerAddViewModel = value;
                OnPropertyChanged(nameof(ViewCustomerAddViewModel));
            }
        }



        //private V.ViewCustomerSearch _viewCustomerSearch = null;
        //public V.ViewCustomerSearch ViewCustomerSearch
        //{
        //    get { return _viewCustomerSearch; }
        //    set
        //    {
        //        _viewCustomerSearch = value;
        //        OnPropertyChanged(nameof(ViewCustomerSearch));
        //    }
        //}
        //private VM.ViewCustomerSearchViewModel _viewCustomerSearchViewModel;
        //public VM.ViewCustomerSearchViewModel ViewCustomerSearchViewModel
        //{
        //    get { return _viewCustomerSearchViewModel; }
        //    set
        //    {
        //        _viewCustomerSearchViewModel = value;
        //        OnPropertyChanged(nameof(ViewCustomerSearchViewModel));
        //    }
        //}




        private V.ViewCustomers _viewCustomers = null;
        public V.ViewCustomers ViewCustomers
        {
            get { return _viewCustomers; }
            set
            {
                _viewCustomers = value;
                OnPropertyChanged(nameof(ViewCustomers));
            }
        }
        private VM.ViewCustomersViewModel _viewCustomersViewModel;
        public VM.ViewCustomersViewModel ViewCustomersViewModel
        {
            get { return _viewCustomersViewModel; }
            set
            {
                _viewCustomersViewModel = value;
                OnPropertyChanged(nameof(ViewCustomersViewModel));
            }
        }




        private V.ViewDeliveryAdd _viewDeliveryAdd = null;
        public V.ViewDeliveryAdd ViewDeliveryAdd
        {
            get { return _viewDeliveryAdd; }
            set
            {
                _viewDeliveryAdd = value;
                OnPropertyChanged(nameof(ViewDeliveryAdd));
            }
        }
        private VM.ViewDeliveryAddViewModel _viewDeliveryAddViewModel;
        public VM.ViewDeliveryAddViewModel ViewDeliveryAddViewModel
        {
            get { return _viewDeliveryAddViewModel; }
            set
            {
                _viewDeliveryAddViewModel = value;
                OnPropertyChanged(nameof(ViewDeliveryAddViewModel));
            }
        }



        private V.ViewMainStock _viewMainStock = null;
        public V.ViewMainStock ViewMainStock
        {
            get { return _viewMainStock; }
            set
            {
                _viewMainStock = value;
                OnPropertyChanged(nameof(ViewMainStock));
            }
        }
        private VM.ViewMainStockViewModel _viewMainStockViewModel;
        public VM.ViewMainStockViewModel ViewMainStockViewModel
        {
            get { return _viewMainStockViewModel; }
            set
            {
                _viewMainStockViewModel = value;
                OnPropertyChanged(nameof(ViewMainStockViewModel));
            }
        }




        private V.ViewMenuWindow _viewMenuWindow = null;
        public V.ViewMenuWindow ViewMenuWindow
        {
            get { return _viewMenuWindow; }
            set
            {
                _viewMenuWindow = value;
                OnPropertyChanged(nameof(ViewMenuWindow));
            }
        }
        private VM.ViewMenuWindowViewModel _viewMenuWindowViewModel;
        public VM.ViewMenuWindowViewModel ViewMenuWindowViewModel
        {
            get { return _viewMenuWindowViewModel; }
            set
            {
                _viewMenuWindowViewModel = value;
                OnPropertyChanged(nameof(ViewMenuWindowViewModel));
            }
        }


        //private V.ViewNewProductAdd _viewNewProductAdd = null;
        //public V.ViewNewProductAdd ViewNewProductAdd
        //{
        //    get { return _viewNewProductAdd; }
        //    set
        //    {
        //        _viewNewProductAdd = value;
        //        OnPropertyChanged(nameof(ViewNewProductAdd));
        //    }
        //}
        //private VM.ViewNewProductAddViewModel _viewNewProductAddViewModel;
        //public VM.ViewNewProductAddViewModel ViewNewProductAddViewModel
        //{
        //    get { return _viewNewProductAddViewModel; }
        //    set
        //    {
        //        _viewNewProductAddViewModel = value;
        //        OnPropertyChanged(nameof(ViewNewProductAddViewModel));
        //    }
        //}


        //private V.ViewProductSearch _viewProductSearch = null;
        //public V.ViewProductSearch ViewProductSearch
        //{
        //    get { return _viewProductSearch; }
        //    set
        //    {
        //        _viewProductSearch = value;
        //        OnPropertyChanged(nameof(ViewProductSearch));
        //    }
        //}
        //private VM.ViewProductSearchViewModel _viewProductSearchViewModel;
        //public VM.ViewProductSearchViewModel ViewProductSearchViewModel
        //{
        //    get { return _viewProductSearchViewModel; }
        //    set
        //    {
        //        _viewProductSearchViewModel = value;
        //        OnPropertyChanged(nameof(ViewProductSearchViewModel));
        //    }
        //}


        private V.ViewServiceDone _viewServiceDone = null;
        public V.ViewServiceDone ViewServiceDone
        {
            get { return _viewServiceDone; }
            set
            {
                _viewServiceDone = value;
                OnPropertyChanged(nameof(ViewServiceDone));
            }
        }
        private VM.ViewServiceDoneViewModel _viewServiceDoneViewModel;
        public VM.ViewServiceDoneViewModel ViewServiceDoneViewModel
        {
            get { return _viewServiceDoneViewModel; }
            set
            {
                _viewServiceDoneViewModel = value;
                OnPropertyChanged(nameof(ViewServiceDoneViewModel));
            }
        }


        private V.ViewServicesHistory _viewServicesHistory = null;
        public V.ViewServicesHistory ViewServicesHistory
        {
            get { return _viewServicesHistory; }
            set
            {
                _viewServicesHistory = value;
                OnPropertyChanged(nameof(ViewServicesHistory));
            }
        }
        private VM.ViewServicesHistoryViewModel _viewServicesHistoryViewModel;
        public VM.ViewServicesHistoryViewModel ViewServicesHistoryViewModel
        {
            get { return _viewServicesHistoryViewModel; }
            set
            {
                _viewServicesHistoryViewModel = value;
                OnPropertyChanged(nameof(ViewServicesHistoryViewModel));
            }
        }
        #endregion
        #region konstruktor
        public MainWindowViewModel(V.ViewActualStock viewActualStock, VM.ViewActualStockViewModel viewActualStockViewModel,
            V.ViewAuthors viewAuthors, VM.ViewAuthorsViewModel viewAuthorsViewModel,
            V.ViewCustomerAdd viewCustomerAdd, VM.ViewCustomerAddViewModel viewCustomerAddViewModel,
            V.ViewCustomerSearch vcsd, VM.ViewCustomerSearchViewModel vcsdViewModel,
            V.ViewCustomerSearch vcsh, VM.ViewCustomerSearchViewModel vcshViewModel,
            V.ViewCustomers viewCustomers, VM.ViewCustomersViewModel viewCustomersViewModel,
            V.ViewDeliveryAdd viewDeliveryAdd, VM.ViewDeliveryAddViewModel viewDeliveryAddViewModel,
            V.ViewMainStock viewMainStock, VM.ViewMainStockViewModel viewMainStockViewModel,
            V.ViewMenuWindow viewMenuWindow, VM.ViewMenuWindowViewModel viewMenuWindowViewModel,
            V.ViewNewProductAdd viewNewProductAdd, VM.ViewNewProductAddViewModel viewNewProductAddViewModel,
            V.ViewProductSearch vpsa1, VM.ViewProductSearchViewModel vpsa1ViewModel,
            V.ViewProductSearch vpsa2, VM.ViewProductSearchViewModel vpsa2ViewModel,
            V.ViewProductSearch vpsd1, VM.ViewProductSearchViewModel vpsd1ViewModel,
            V.ViewProductSearch vpsd2, VM.ViewProductSearchViewModel vpsd2ViewModel,
            V.ViewServiceDone viewServiceDone, VM.ViewServiceDoneViewModel viewServiceDoneViewModel,
            V.ViewServicesHistory viewServicesHistory, VM.ViewServicesHistoryViewModel viewServicesHistoryViewModel)
        {
            ViewActualStock = viewActualStock;
            ViewActualStockViewModel = viewActualStockViewModel;

            ViewAuthors = viewAuthors;
            ViewAuthorsViewModel = viewAuthorsViewModel;

            ViewCustomerAdd = viewCustomerAdd;
            ViewCustomerAddViewModel = viewCustomerAddViewModel;
            viewCustomerAddViewModel.ChangeView += ChangeViewTo;

            //ViewCustomerSearch = viewCustomerSearch;
            //ViewCustomerSearchViewModel = viewCustomerSearchViewModel;
            //viewCustomerSearchViewModel.ChangeView += ChangeViewTo;

            ViewCustomers = viewCustomers;
            ViewCustomersViewModel = viewCustomersViewModel;
            viewCustomersViewModel.ChangeView += ChangeViewTo;

            ViewDeliveryAdd = viewDeliveryAdd;
            ViewDeliveryAddViewModel = viewDeliveryAddViewModel;
            ViewDeliveryAddViewModel.ViewProductSearch1 = vpsa1;
            ViewDeliveryAddViewModel.ViewProductSearchViewModel1 = vpsa1ViewModel;
            ViewDeliveryAddViewModel.ViewProductSearch2 = vpsa2;
            ViewDeliveryAddViewModel.ViewProductSearchViewModel2 = vpsa2ViewModel;
            viewDeliveryAddViewModel.ChangeView += ChangeViewTo;
            ViewDeliveryAddViewModel.ViewNewProductAdd = viewNewProductAdd;
            ViewDeliveryAddViewModel.ViewNewProductAddViewModel = viewNewProductAddViewModel;

            ViewMainStock = viewMainStock;
            ViewMainStockViewModel = viewMainStockViewModel;
            viewMainStockViewModel.ChangeView += ChangeViewTo;

            ViewMenuWindow = viewMenuWindow;
            ViewMenuWindowViewModel = viewMenuWindowViewModel;
            viewMenuWindowViewModel.ChangeView += ChangeViewTo;

            //ViewNewProductAdd = viewNewProductAdd;
            //ViewNewProductAddViewModel = viewNewProductAddViewModel;

            //ViewProductSearch = viewProductSearch;
            //ViewProductSearchViewModel = viewProductSearchViewModel;

            ViewServiceDone = viewServiceDone;
            ViewServiceDoneViewModel = viewServiceDoneViewModel;
            vcsdViewModel.ChangeView += ChangeViewTo;
            ViewServiceDoneViewModel.ViewCustomerSearch = vcsd;
            ViewServiceDoneViewModel.ViewCustomerSearchViewModel = vcsdViewModel;
            ViewServiceDoneViewModel.ViewProductSearch1 = vpsd1;
            ViewServiceDoneViewModel.ViewProductSearchViewModel1 = vpsd1ViewModel;
            ViewServiceDoneViewModel.ViewProductSearch2 = vpsd2;
            ViewServiceDoneViewModel.ViewProductSearchViewModel2 = vpsd2ViewModel;
            viewServiceDoneViewModel.ChangeView += ChangeViewTo;

            ViewServicesHistory = viewServicesHistory;
            ViewServicesHistoryViewModel = viewServicesHistoryViewModel;
            vcshViewModel.ChangeView += ChangeViewTo;
            ViewServicesHistoryViewModel.ViewCustomerSearch = vcsh;
            ViewServicesHistoryViewModel.ViewCustomerSearchViewModel = vcshViewModel;
            viewServicesHistoryViewModel.ChangeView += ChangeViewTo;

            _previousViews = new Stack<UserControl>();
            CurrentView = viewMenuWindow;
        }
        #endregion

        private void ChangeViewTo(string view) //Metoda do zmiany widoków
        {
            PreviousViews.Push(CurrentView);
            switch (view)
            {
                case "ViewActualStock":
                    CurrentView = ViewActualStock;
                    break;
                case "ViewAuthors":
                    CurrentView = ViewAuthors;
                    break;
                case "ViewCustomerAdd":
                    CurrentView = ViewCustomerAdd;
                    break;
                case "ViewCustomerSearch":
                    //CurrentView = ViewCustomerSearch;
                    break;
                case "ViewCustomers":
                    CurrentView = ViewCustomers;
                    break;
                case "ViewDeliveryAdd":
                    CurrentView = ViewDeliveryAdd;
                    break;
                case "ViewMainStock":
                    CurrentView = ViewMainStock;
                    break;
                case "ViewMenuWindow":
                    CurrentView = ViewMenuWindow;
                    break;
                case "ViewNewProductAdd":
                    //CurrentView = ViewNewProductAdd;
                    break;
                case "ViewProductSearch":
                    //CurrentView = ViewProductSearch;
                    break;
                case "ViewServiceDone":
                    CurrentView = ViewServiceDone;
                    break;
                case "ViewServicesHistory":
                    CurrentView = ViewServicesHistory;
                    break;
                default:
                    Debug.WriteLine("Coś poszło nie tak! w funkcji ChangeViewTo");
                    break;
            }
        }
        private void ChangeViewTo(object view)
        {
            PreviousViews.Push(CurrentView);
            CurrentView = view as UserControl;
        }

        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { ChangeViewTo("ViewMenuWindow"); },
                        arg => true);
                return _gotoMainMenu;
            }
        }
        private ICommand _goBack = null;
        public ICommand GoBack
        {
            get
            {
                if (_goBack == null)
                    _goBack = new ViewModelBase.RelayCommand(
                        arg => { 
                            if(PreviousViews != null && PreviousViews.Count > 0)
                                CurrentView = PreviousViews.Pop();
                            if (CurrentView.Equals(ViewMenuWindow))
                                PreviousViews.Clear();
                        }, arg => true);
                return _goBack;
            }
        }

        //Do kasacji
        #region ClientRecord
        //private ClientRecord clientRecord = new ClientRecord();
        //public ObservableCollection<Client> Clients
        //{
        //    get
        //    {
        //        ObservableCollection<Client> list = new ObservableCollection<Client>();
        //        foreach (var v in clientRecord.Clients)
        //            list.Add(v);

        //        return list;
        //    }
        //    set { }
        //}
        //public string ClientName { get; set; }
        //public string ClientSurname { get; set; }
        //public string ClientPhone { get; set; }
        //public Client CurrentClient { get; set; }
        //private void ClientDataClear()
        //{
        //    ClientName = "";
        //    ClientSurname = "";
        //    ClientPhone = "";
        //    CurrentClient = null;
        //}
        //#region Search
        //private ICommand _searchClient;
        //public ICommand SearchClient
        //{
        //    get
        //    {
        //        return _searchClient ?? (_searchClient = new RelayCommand(
        //           x =>
        //           {
        //               clientRecord.GetClients(ClientName, ClientSurname);
        //               OnPropertyChanged(nameof(Clients));
        //           }));
        //    }
        //}
        //private ICommand _selectClient;
        //public ICommand SelectClient
        //{
        //    get
        //    {
        //        return _selectClient ?? (_selectClient = new RelayCommand(
        //           x =>
        //           {
        //               ClientName = CurrentClient.Name;
        //               ClientSurname = CurrentClient.LastName;
        //               ClientPhone = CurrentClient.PhoneNumber;
        //               //GotoViewServiceDone();
        //           },
        //           x =>
        //           {
        //               return CurrentClient != null;
        //           }
        //           ));
        //    }
        //}
        #endregion
        #region AddNew
        //private ICommand _addNewClient;
        //public ICommand AddNewClient
        //{
        //    get
        //    {
        //        return _addNewClient ?? (_addNewClient = new RelayCommand(
        //           x =>
        //           {
        //               clientRecord.AddNew(ClientName, ClientSurname, ClientPhone);
        //               //ClientName = "";
        //               //ClientSurname = "";
        //               //ClientPhone = "";
        //               ClientDataClear();
        //               OnPropertyChanged(nameof(ClientName));
        //               OnPropertyChanged(nameof(ClientSurname));
        //               OnPropertyChanged(nameof(ClientPhone));
        //               //Informacja zwrotna przydalaby sie
        //               //GotoPreviousView();
        //           },
        //           x =>
        //           {
        //               return !string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(ClientSurname) && !string.IsNullOrEmpty(ClientPhone);
        //           }));
        //    }
        //}
        #endregion
        #region Inventory
        //Inventory inventory = new Inventory();
        //private List<SingleUseProduct> _usedSingleUseProducts = new List<SingleUseProduct>();
        //private List<Product> _usedProducts = new List<Product>();
        //private bool IsSingleProducts;
        //public SingleUseProduct CurrentProduct { get; set; }
        //private void InventoryDataClear()
        //{
        //    ProductName = "";
        //}
        //public ObservableCollection<SingleUseProduct> AllProductsRecord
        //{
        //    get
        //    {
        //        ObservableCollection<SingleUseProduct> list = new ObservableCollection<SingleUseProduct>();
        //        if (IsSingleProducts)
        //        {
        //            foreach (var v in inventory.SingleUseProducts)
        //                list.Add(v);
        //        }
        //        else
        //        {
        //            foreach (var v in inventory.Products)
        //                list.Add(v);
        //        }

        //        return list;
        //    }
        //    set
        //    { }
        //}
        //public ObservableCollection<SingleUseProduct> UsedSingleUseProducts
        //{
        //    get
        //    {
        //        ObservableCollection<SingleUseProduct> list = new ObservableCollection<SingleUseProduct>();
        //        foreach (var v in _usedSingleUseProducts)
        //            list.Add(v);

        //        return list;
        //    }
        //    set { }
        //}
        //public ObservableCollection<Product> UsedProducts
        //{
        //    get
        //    {
        //        ObservableCollection<Product> list = new ObservableCollection<Product>();
        //        foreach (var v in _usedProducts)
        //            list.Add(v);

        //        return list;
        //    }
        //    set { }
        //}
        //private ICommand _singleUseProductPlusButton;
        //public ICommand SingleUseProductPlusButton
        //{
        //    get
        //    {
        //        return _singleUseProductPlusButton ?? (_singleUseProductPlusButton = new RelayCommand(
        //           x =>
        //           {
        //               ProductName = "";
        //               IsSingleProducts = true;
        //               //GotoViewProductSearch();
        //           }));
        //    }
        //}
        //private ICommand _productPlusButton;
        //public ICommand ProductPlusButton
        //{
        //    get
        //    {
        //        return _productPlusButton ?? (_productPlusButton = new RelayCommand(
        //           x =>
        //           {
        //               ProductName = "";
        //               IsSingleProducts = false;
        //               //GotoViewProductSearch();
        //           }));
        //    }
        //}
        //public string ProductName { get; set; }
        //private ICommand _selectProduct;
        //public ICommand SelectProduct
        //{
        //    get
        //    {
        //        return _selectProduct ?? (_selectProduct = new RelayCommand(
        //           x =>
        //           {
        //               if (IsSingleProducts)
        //               {
        //                   _usedSingleUseProducts.Add(CurrentProduct);
        //               }
        //               else
        //               {
        //                   _usedProducts.Add(CurrentProduct as Product);
        //               }
        //               //GotoViewServiceDone();
        //           },
        //            x =>
        //            {
        //                return CurrentProduct != null;
        //            }));
        //    }
        //}
        //private ICommand _searchProduct;
        //public ICommand SearchProduct
        //{
        //    get
        //    {
        //        return _searchProduct ?? (_searchProduct = new RelayCommand(
        //           x =>
        //           {
        //               if (IsSingleProducts)
        //               {
        //                   inventory.GetSingleUseProducts(ProductName);
        //               }
        //               else
        //               {
        //                   inventory.GetProducts(ProductName);
        //               }
        //               OnPropertyChanged(nameof(AllProductsRecord));
        //           }));
        //    }
        //}
        #endregion
        #region VisitRecord
        //private ServiceRecord serviceRecord = new ServiceRecord();
        //public ObservableCollection<string> Services
        //{
        //    get
        //    {
        //        ObservableCollection<string> list = new ObservableCollection<string>();
        //        foreach (var v in serviceRecord.Services)
        //            list.Add(v.Name);

        //        return list;
        //    }
        //    set { }
        //}
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
        
    }
}
