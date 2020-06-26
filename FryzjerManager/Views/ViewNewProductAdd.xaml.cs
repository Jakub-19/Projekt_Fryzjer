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
    /// Logika interakcji dla klasy ViewNewProductAdd.xaml
    /// </summary>
    public partial class ViewNewProductAdd : UserControl
    {
        public static readonly DependencyProperty vm = DependencyProperty.Register(

          "ViewModel",
          typeof(ViewModel.ViewsViewModels.ViewNewProductAddViewModel),
          typeof(ViewNewProductAdd),
          null);

        public ViewModel.ViewsViewModels.ViewNewProductAddViewModel ViewModel
        {
            get { return (ViewModel.ViewsViewModels.ViewNewProductAddViewModel)GetValue(vm); }
            set { SetValue(vm, value); }
        }
        public ViewNewProductAdd()
        {
            InitializeComponent();
        }
        private void SingleUseCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            MultiUseCheckbox.IsChecked = false;
            CapacityTextBox.IsEnabled = false;
            CapacityTextBox.Text = "";
        }

        private void MultiUseCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            SingleUseCheckbox.IsChecked = false;
            CapacityTextBox.IsEnabled = true;
        }
    }
}
