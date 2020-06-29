﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    public class ViewMainStockViewModel : ViewModelBase.ViewModelBase
    {
        public event Action<string> ChangeView;

        private ICommand _gotoDeliveryAdd = null;
        public ICommand GotoDeliveryAdd
        {
            get
            {
                if (_gotoDeliveryAdd == null)
                    _gotoDeliveryAdd = new ViewModelBase.RelayCommand(
                        arg => { ChangeView?.Invoke("ViewDeliveryAdd"); },
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
                        arg => { ChangeView?.Invoke("ViewActualStock"); },
                        arg => true);
                return _gotoActualStock;
            }
        }
    }
}
