using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Collections.ObjectModel;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    using V = Views;
    using VM = ViewsViewModels;
    public class ViewServicesHistoryViewModel : ViewModelBase.ViewModelBase
    {
        #region Formularz wyszukiwania klienta
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
                ViewCustomerSearchViewModel.GoHomeAction += GotoMainMenuFunc;
                OnPropertyChanged(nameof(ViewCustomerSearchViewModel));
            }
        }
        #endregion
        public event Action<object, bool> ChangeView;
        private ICommand _selectCustomer = null;
        public ICommand SelectCustomer
        {
            get
            {
                if (_selectCustomer == null)
                    _selectCustomer = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke(ViewCustomerSearch, true); },
                        arg => true);
                return _selectCustomer;
            }
        }

        private void GetClient(Client client)
        {
            CurrentClient = client;
            OnPropertyChanged(nameof(CurrentClient));
            ChangeView?.Invoke("ViewServicesHistory", false);
            visitRecord.GetVisits(CurrentClient);
            OnPropertyChanged(nameof(Visits));
        }
        public Client CurrentClient { get; set; }
        
        private VisitRecord visitRecord = new VisitRecord();

        public ObservableCollection<Visit> Visits {
            get
            {
                ObservableCollection<Visit> list = new ObservableCollection<Visit>();
                foreach (var v in visitRecord.Visits)
                    list.Add(v);

                return list;
            } }
        private Visit _currentVisit = null;
        public Visit CurrentVisit {
            get => _currentVisit;
            set {
                _currentVisit = value;
                OnPropertyChanged(nameof(Services)); 
            } 
        }
        public ObservableCollection<Service> Services
        {
            get
            {
                ObservableCollection<Service> list = new ObservableCollection<Service>();
                if(CurrentVisit != null)
                foreach (var v in CurrentVisit.TypeOfService)
                    list.Add(v);

                return list;
            }
        }

        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { GotoMainMenuFunc(); },
                        arg => true);
                return _gotoMainMenu;
            }
        }
        private void GotoMainMenuFunc()
        {
            ChangeView?.Invoke("ViewMenuWindow", false);
            Clear();
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
                            GoBackAction?.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }

        private void Clear()
        {
            CurrentClient = null;
            CurrentVisit = null;
            visitRecord.Clear();
            OnPropertyChanged(nameof(Visits));
            OnPropertyChanged(nameof(CurrentClient));
            ViewCustomerSearchViewModel.Clear();
        }
    }
}
