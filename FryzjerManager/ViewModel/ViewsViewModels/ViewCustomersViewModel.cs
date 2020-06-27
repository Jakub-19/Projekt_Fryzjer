using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewCustomersViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<string> ChangeView;

        private ICommand _gotoCustomerAdd = null;
        public ICommand GotoCustomerAdd
        {
            get
            {
                if (_gotoCustomerAdd == null)
                    _gotoCustomerAdd = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewCustomerAdd"); },
                        arg => true);
                return _gotoCustomerAdd;
            }
        }
        private ICommand _gotoServicesHistory = null;
        public ICommand GotoServicesHistory
        {
            get
            {
                if (_gotoServicesHistory == null)
                    _gotoServicesHistory = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewServicesHistory"); },
                        arg => true);
                return _gotoServicesHistory;
            }
        }
    }
}
