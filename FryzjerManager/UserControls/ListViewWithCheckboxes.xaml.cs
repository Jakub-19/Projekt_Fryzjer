using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FryzjerManager.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy ListViewWithCheckboxes.xaml
    /// </summary>
    public partial class ListViewWithCheckboxes : UserControl
    {
        public ListViewWithCheckboxes()
        {
            InitializeComponent();
        }
        private void OnUncheckItem(object sender, RoutedEventArgs e)
        {
            selectAll.IsChecked = false;
        }
        private void OnSelectAllChanged(object sender, RoutedEventArgs e)
        {
            if (selectAll.IsChecked.HasValue && selectAll.IsChecked.Value)
                checkedListView.SelectAll();
            else
                checkedListView.UnselectAll();
        }
    }
}
