using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Text.RegularExpressions;

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
                        arg => { Regex reg = new Regex(@"^[0-9]{9}$"); return !string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(ClientSurname) && !string.IsNullOrEmpty(ClientPhone) && reg.IsMatch(ClientPhone); });
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
