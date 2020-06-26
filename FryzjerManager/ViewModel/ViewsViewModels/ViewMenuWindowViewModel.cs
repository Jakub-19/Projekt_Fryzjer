using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewMenuWindowViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<string> ChangeView;
        private ICommand _gotoCustomers = null;
        public ICommand GotoCustomers
        {
            get
            {
                if (_gotoCustomers == null)
                    _gotoCustomers = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewCustomers"); },
                        arg => true);
                return _gotoCustomers;
            }
        }
    }
}
