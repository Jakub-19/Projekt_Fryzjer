using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FryzjerManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ViewCustomerSearch.xaml
    /// </summary>
    public partial class ViewCustomerSearch : UserControl
    {
        public static readonly DependencyProperty vm = DependencyProperty.Register(

          "ViewModel",
          typeof(ViewModel.ViewsViewModels.ViewCustomerSearchViewModel),
          typeof(ViewCustomerSearch),
          null);

        public ViewModel.ViewsViewModels.ViewCustomerSearchViewModel ViewModel
        {
            get { return (ViewModel.ViewsViewModels.ViewCustomerSearchViewModel)GetValue(vm); }
            set { SetValue(vm, value); }
        }
        public ViewCustomerSearch()
        {
            InitializeComponent();
        }
    }
}
