using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewCustomerAddViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<string> ChangeView;

        #region Komendy przyciskow

        private ICommand _addCustomer = null;
        public ICommand AddCustomer
        {
            get
            {
                if (_addCustomer == null)
                    _addCustomer = new ViewModelBase.RelayCommand(
                        arg => {
                            ClientRecord clientRecord = new ClientRecord();
                            clientRecord.AddNew(ClientName, ClientSurname, ClientPhone);
                            Clear();
                            ChangeView?.Invoke("ViewCustomers"); 
                        },
                        arg => !string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(ClientSurname) && !string.IsNullOrEmpty(ClientPhone));
                return _addCustomer;
            }
        }
        #endregion
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhone { get; set; }

        private void Clear()
        {
            ClientName = "";
            ClientSurname = "";
            ClientPhone = "";
            OnPropertyChanged(nameof(ClientName));
            OnPropertyChanged(nameof(ClientSurname));
            OnPropertyChanged(nameof(ClientPhone));
        }
    }
}
