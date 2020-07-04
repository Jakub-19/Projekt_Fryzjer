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
            viewActualStockViewModel.ChangeView += ChangeViewTo;
            viewActualStockViewModel.GoBackAction += ChangeViewToPrevious;

            ViewAuthors = viewAuthors;
            ViewAuthorsViewModel = viewAuthorsViewModel;
            viewAuthorsViewModel.ChangeView += ChangeViewTo;
            viewAuthorsViewModel.GoBackAction += ChangeViewToPrevious;

            ViewCustomerAdd = viewCustomerAdd;
            ViewCustomerAddViewModel = viewCustomerAddViewModel;
            viewCustomerAddViewModel.ChangeView += ChangeViewTo;
            viewCustomerAddViewModel.GoBackAction += ChangeViewToPrevious;

            ViewCustomers = viewCustomers;
            ViewCustomersViewModel = viewCustomersViewModel;
            viewCustomersViewModel.ChangeView += ChangeViewTo;
            viewCustomersViewModel.GoBackAction += ChangeViewToPrevious;

            ViewDeliveryAdd = viewDeliveryAdd;
            ViewDeliveryAddViewModel = viewDeliveryAddViewModel;
            ViewDeliveryAddViewModel.ViewProductSearch1 = vpsa1;
            ViewDeliveryAddViewModel.ViewProductSearchViewModel1 = vpsa1ViewModel;
            ViewDeliveryAddViewModel.ViewProductSearch2 = vpsa2;
            ViewDeliveryAddViewModel.ViewProductSearchViewModel2 = vpsa2ViewModel;
            viewDeliveryAddViewModel.ChangeView += ChangeViewTo;
            viewDeliveryAddViewModel.GoBackAction += ChangeViewToPrevious;
            ViewDeliveryAddViewModel.ViewNewProductAdd = viewNewProductAdd;
            ViewDeliveryAddViewModel.ViewNewProductAddViewModel = viewNewProductAddViewModel;

            ViewMainStock = viewMainStock;
            ViewMainStockViewModel = viewMainStockViewModel;
            viewMainStockViewModel.ChangeView += ChangeViewTo;
            viewMainStockViewModel.GoBackAction += ChangeViewToPrevious;

            ViewMenuWindow = viewMenuWindow;
            ViewMenuWindowViewModel = viewMenuWindowViewModel;
            viewMenuWindowViewModel.ChangeView += ChangeViewTo;

            ViewServiceDone = viewServiceDone;
            ViewServiceDoneViewModel = viewServiceDoneViewModel;
            ViewServiceDoneViewModel.ViewCustomerSearch = vcsd;
            ViewServiceDoneViewModel.ViewCustomerSearchViewModel = vcsdViewModel;
            ViewServiceDoneViewModel.ViewProductSearch1 = vpsd1;
            ViewServiceDoneViewModel.ViewProductSearchViewModel1 = vpsd1ViewModel;
            ViewServiceDoneViewModel.ViewProductSearch2 = vpsd2;
            ViewServiceDoneViewModel.ViewProductSearchViewModel2 = vpsd2ViewModel;
            viewServiceDoneViewModel.ChangeView += ChangeViewTo;
            viewServiceDoneViewModel.GoBackAction += ChangeViewToPrevious;

            ViewServicesHistory = viewServicesHistory;
            ViewServicesHistoryViewModel = viewServicesHistoryViewModel;
            ViewServicesHistoryViewModel.ViewCustomerSearch = vcsh;
            ViewServicesHistoryViewModel.ViewCustomerSearchViewModel = vcshViewModel;
            viewServicesHistoryViewModel.ChangeView += ChangeViewTo;
            viewServicesHistoryViewModel.GoBackAction += ChangeViewToPrevious;

            _previousViews = new Stack<UserControl>();
            CurrentView = viewMenuWindow;
        }
        #endregion

        private void ChangeViewTo(object view)
        {
            if (view as string == null)
                CurrentView = view as UserControl;
            else
            {
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
                        PreviousViews.Clear();
                        break;
                    case "ViewServiceDone":
                        CurrentView = ViewServiceDone;
                        break;
                    case "ViewServicesHistory":
                        CurrentView = ViewServicesHistory;
                        break;
                    default:
                        Debug.WriteLine("Widok nie istnieje lub nie jest obsługiwany (ChangeViewTo)");
                        break;
                }
            }
        }
        private void ChangeViewTo(object view, bool saveOnStack)
        {
            if(saveOnStack)
                PreviousViews.Push(CurrentView);
            ChangeViewTo(view);
        }

        private void ChangeViewToPrevious()
        {
            if (PreviousViews != null && PreviousViews.Count > 0)
            {
                var temp = CurrentView;
                while (CurrentView.Equals(temp))
                    CurrentView = PreviousViews.Pop();
            }
            if (CurrentView.Equals(ViewMenuWindow))
                PreviousViews.Clear();
        }


        //Do kasacji
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
