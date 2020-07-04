using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    //VM podmenu (magazynu)
    public class ViewMainStockViewModel : ViewModelBase.ViewModelBase
    {
        //Nawigacja
        public event Action<string, bool> ChangeView;

        private ICommand _gotoDeliveryAdd = null;
        public ICommand GotoDeliveryAdd
        {
            get
            {
                if (_gotoDeliveryAdd == null)
                    _gotoDeliveryAdd = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewDeliveryAdd", true); },
                        arg => true);
                return _gotoDeliveryAdd;
            }
        }
        private ICommand _gotoActualStock = null;
        public ICommand GotoActualStock
        {
            get
            {
                if (_gotoActualStock == null)
                    _gotoActualStock = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewActualStock", true); },
                        arg => true);
                return _gotoActualStock;
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
