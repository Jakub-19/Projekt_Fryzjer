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
    using V = Views;
    using VM = ViewsViewModels;
    public class ViewDeliveryAddViewModel : ViewModelBase.ViewModelBase
    {
        private V.ViewProductSearch _viewProductSearch = null;
        public V.ViewProductSearch ViewProductSearch
        {
            get { return _viewProductSearch; }
            set
            {
                _viewProductSearch = value;
                OnPropertyChanged(nameof(ViewProductSearch));
            }
        }
        private VM.ViewProductSearchViewModel _viewProductSearchViewModel;
        public VM.ViewProductSearchViewModel ViewProductSearchViewModel
        {
            get { return _viewProductSearchViewModel; }
            set
            {
                _viewProductSearchViewModel = value;
                OnPropertyChanged(nameof(ViewProductSearchViewModel));
            }
        }
        public event Action<object> ChangeView;

    }
}
