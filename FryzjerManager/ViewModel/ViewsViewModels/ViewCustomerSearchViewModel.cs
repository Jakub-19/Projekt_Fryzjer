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
        public event Action<string> ChangeView;

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
        private ICommand _selectClient = null;
        public ICommand SelectClient
        {
            get
            {
                if (_searchClient == null)
                    _searchClient = new ViewModelBase.RelayCommand(
                        arg => {
                            clientRecord.GetClients(ClientName, ClientSurname);
                            OnPropertyChanged(nameof(Clients));
                        },
                        arg => CurrentClient != null && false);
                return _searchClient;
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

        private void Clear()
        {
            ClientName = "";
            ClientSurname = "";
            CurrentClient = null; 
        }
    }
}