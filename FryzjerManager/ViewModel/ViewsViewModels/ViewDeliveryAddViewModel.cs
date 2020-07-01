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
    public class ViewDeliveryAddViewModel : ViewModelBase.ViewModelBase
    {
        //1 to wielorazowe a 2 to jednorazowe
        private V.ViewProductSearch _viewProductSearch1 = null;
        public V.ViewProductSearch ViewProductSearch1
        {
            get { return _viewProductSearch1; }
            set
            {
                _viewProductSearch1 = value;
                OnPropertyChanged(nameof(ViewProductSearch1));
            }
        }
        private ViewProductSearchViewModel _viewProductSearchViewModel1;
        public ViewProductSearchViewModel ViewProductSearchViewModel1
        {
            get { return _viewProductSearchViewModel1; }
            set
            {
                _viewProductSearchViewModel1 = value;
                OnPropertyChanged(nameof(ViewProductSearchViewModel1));
            }
        }
        private V.ViewProductSearch _viewProductSearch2 = null;
        public V.ViewProductSearch ViewProductSearch2
        {
            get { return _viewProductSearch2; }
            set
            {
                _viewProductSearch2 = value;
                OnPropertyChanged(nameof(ViewProductSearch2));
            }
        }
        private ViewProductSearchViewModel _viewProductSearchViewModel2;
        public ViewProductSearchViewModel ViewProductSearchViewModel2
        {
            get { return _viewProductSearchViewModel2; }
            set
            {
                _viewProductSearchViewModel2 = value;
                OnPropertyChanged(nameof(ViewProductSearchViewModel2));
            }
        }

        private V.ViewNewProductAdd _viewNewProductAdd = null;
        public V.ViewNewProductAdd ViewNewProductAdd
        {
            get { return _viewNewProductAdd; }
            set
            {
                _viewNewProductAdd = value;
                OnPropertyChanged(nameof(ViewNewProductAdd));
            }
        }
        private ViewNewProductAddViewModel _viewNewProductAddViewModel;
        public ViewNewProductAddViewModel ViewNewProductAddViewModel
        {
            get { return _viewNewProductAddViewModel; }
            set
            {
                _viewNewProductAddViewModel = value;
                OnPropertyChanged(nameof(ViewNewProductAddViewModel));
            }
        }

        public event Action<object> ChangeView;

    }
}
