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
using System.Diagnostics;


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
        //Zdarzenie wywolywane kiedy ktorykolwiek z checkboxow zostanie odznaczony
        private void OnUncheckItem(object sender, RoutedEventArgs e)
        {
            selectAll.IsChecked = false;
        }
        //Zdarzenie wywolywane po kliknieciu checkboxa "zaznacz wszystkie"
        private void OnSelectAllChanged(object sender, RoutedEventArgs e)
        {
            if (selectAll.IsChecked.HasValue && selectAll.IsChecked.Value)
                checkedListView.SelectAll();
            else
                checkedListView.UnselectAll();
        }
        //Lista wszystkich opcji
        public static readonly DependencyProperty src = DependencyProperty.Register("Src", typeof(ObservableCollection<object>), typeof(ListViewWithCheckboxes), new FrameworkPropertyMetadata(null));
        public ObservableCollection<object> Src
        {
            get { return (ObservableCollection<object>)GetValue(src); }
            set { SetValue(src, value); }
        }
        //Lista zaznaczonych opcji
        public static readonly DependencyProperty chk = DependencyProperty.Register("Chk", typeof(ObservableCollection<object>), typeof(ListViewWithCheckboxes), new FrameworkPropertyMetadata(null));
        public ObservableCollection<object> Chk
        {
            get { return (ObservableCollection<object>)GetValue(chk); }
            set { SetValue(chk, value); }
        }
        //Dodanie zaznaczonych opcji do listy
        private void checkedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<object> list = new ObservableCollection<object>();
            foreach(var a in checkedListView.SelectedItems)
                list.Add(a);
            Chk = list;
        }
    }
}
