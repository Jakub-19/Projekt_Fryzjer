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
    /// Logika interakcji dla klasy UsedProduct.xaml
    /// </summary>
    public partial class UsedProduct : UserControl
    {
        public UsedProduct()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty productName = DependencyProperty.Register("ProductName", typeof(string), typeof(TitleBar), new FrameworkPropertyMetadata(null));
        public string ProductName
        {
            get { return (string)GetValue(productName); }
            set { SetValue(productName, value); }
        }
    }
}
