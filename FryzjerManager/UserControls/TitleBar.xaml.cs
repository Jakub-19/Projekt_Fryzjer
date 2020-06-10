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
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent = sender as UIElement;
            // Search up the visual tree to find the first parent window.
            while ((parent is Window) == false)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var window = parent as Window;
            window.DragMove();
        }
    }
}
