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
    /// Logika interakcji dla klasy ViewProductSearch.xaml
    /// </summary>
    public partial class ViewProductSearch : UserControl
    {
        public static readonly DependencyProperty vm = DependencyProperty.Register(

          "ViewModel",
          typeof(ViewModel.ViewsViewModels.ViewProductSearchViewModel),
          typeof(ViewProductSearch),
          null);

        public ViewModel.ViewsViewModels.ViewProductSearchViewModel ViewModel
        {
            get { return (ViewModel.ViewsViewModels.ViewProductSearchViewModel)GetValue(vm); }
            set { SetValue(vm, value); }
        }
        public ViewProductSearch()
        {
            InitializeComponent();
        }
    }
}
