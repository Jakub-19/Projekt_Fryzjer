using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewCustomerSearchViewModel : ViewModelBase.ViewModelBase
    {
        private ICommand _searchClient = null;
        public ICommand SearchClient
        {
            get
            {
                if (_searchClient == null)
                    _searchClient = new ViewModelBase.RelayCommand(
                        arg => {
                            clientRecord.GetClients(ClientName, ClientSurname);
                            OnPropertyChanged(nameof(Clients));
                        },
                        arg => true);
                return _searchClient;
            }
        }
        public event Action<Client> TransferData;

        private ICommand _selectClient = null;
        public ICommand SelectClient
        {
            get
            {
                if (_selectClient == null)
                    _selectClient = new ViewModelBase.RelayCommand(
                        arg => {
                            TransferData?.Invoke(CurrentClient);
                        },
                        arg => CurrentClient != null);
                return _selectClient;
            }
        }

        private ClientRecord clientRecord = new ClientRecord();

        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public Client CurrentClient { get; set; }
        public ObservableCollection<Client> Clients
        {
            get
            {
                ObservableCollection<Client> list = new ObservableCollection<Client>();
                foreach (var v in clientRecord.Clients)
                    list.Add(v);

                return list;
            }
        }

        public event Action GoHomeAction;
        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { GoHomeAction?.Invoke(); },
                        arg => true);
                return _gotoMainMenu;
            }
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
                            GoBackAction?.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }

        public void Clear()
        {
            clientRecord.Clear();
            ClientName = "";
            ClientSurname = "";
            CurrentClient = null;
            OnPropertyChanged(nameof(ClientName));
            OnPropertyChanged(nameof(ClientSurname));
            OnPropertyChanged(nameof(Clients));
    }
    }
}