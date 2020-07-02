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
    }
}