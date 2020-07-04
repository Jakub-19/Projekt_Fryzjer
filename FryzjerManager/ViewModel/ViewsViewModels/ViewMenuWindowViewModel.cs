using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    // VM Głównego menu
    public class ViewMenuWindowViewModel : ViewModelBase.ViewModelBase
    {
        //Nawigacja po aplikacji
        public event Action<string, bool> ChangeView;
        private ICommand _gotoCustomers = null;
        public ICommand GotoCustomers
        {
            get
            {
                if (_gotoCustomers == null)
                    _gotoCustomers = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewCustomers", true); },
                        arg => true);
                return _gotoCustomers;
            }
        }
        private ICommand _gotoServiceDone = null;
        public ICommand GotoServiceDone
        {
            get
            {
                if (_gotoServiceDone == null)
                    _gotoServiceDone = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewServiceDone", true); },
                        arg => true);
                return _gotoServiceDone;
            }
        }
        private ICommand _gotoMainStock = null;
        public ICommand GotoMainStock
        {
            get
            {
                if (_gotoMainStock == null)
                    _gotoMainStock = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewMainStock", true); },
                        arg => true);
                return _gotoMainStock;
            }
        }
        private ICommand _gotoAuthors = null;
        public ICommand GotoAuthors
        {
            get
            {
                if (_gotoAuthors == null)
                    _gotoAuthors = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewAuthors", true); },
                        arg => true);
                return _gotoAuthors;
            }
        }
    }
}
