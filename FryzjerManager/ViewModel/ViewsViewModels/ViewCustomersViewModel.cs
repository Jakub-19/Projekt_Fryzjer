﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    //VM podmenu dot. klientów
    public class ViewCustomersViewModel : ViewModelBase.ViewModelBase
    {
        //Nawigacja
        public event Action<string, bool> ChangeView;

        private ICommand _gotoCustomerAdd = null;
        public ICommand GotoCustomerAdd
        {
            get
            {
                if (_gotoCustomerAdd == null)
                    _gotoCustomerAdd = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewCustomerAdd", true); },
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
                        arg => { ChangeView?.Invoke("ViewServicesHistory", true); },
                        arg => true);
                return _gotoServicesHistory;
            }
        }

        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewMenuWindow", false); },
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
                            GoBackAction.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }
    }
}
