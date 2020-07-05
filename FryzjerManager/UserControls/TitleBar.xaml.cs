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

namespace FryzjerManager.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();
        }
        //Przycisk Domku
        public static readonly DependencyProperty GoHome = DependencyProperty.Register(nameof(goHome), typeof(ICommand), typeof(TitleBar), new FrameworkPropertyMetadata(null));
        public ICommand goHome
        {
            get { return (ICommand)GetValue(GoHome); }
            set { SetValue(GoHome, value); }
        }
        //Przycisk wstecz
        public static readonly DependencyProperty GoBack = DependencyProperty.Register(nameof(goBack), typeof(ICommand), typeof(TitleBar), new FrameworkPropertyMetadata(null));
        public ICommand goBack
        {
            get { return (ICommand)GetValue(GoBack); }
            set { SetValue(GoBack, value); }
        }
        //Tytul okna
        public static readonly DependencyProperty title = DependencyProperty.Register("Title", typeof(string), typeof(TitleBar), new FrameworkPropertyMetadata(null));
        public string Title
        {
            get { return (string)GetValue(title); }
            set { SetValue(title, value); }
        }
        //Mozliwosc przeciagania okna
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent = sender as UIElement;
            while ((parent is Window) == false)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var window = parent as Window;
            window.DragMove();
        }
        //Przycisk minimalizujacy okno
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = sender as UIElement;
            while ((parent is Window) == false)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var window = parent as Window;
            window.WindowState = WindowState.Minimized;
        }
        //Przycisk zamykajacy okno
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
