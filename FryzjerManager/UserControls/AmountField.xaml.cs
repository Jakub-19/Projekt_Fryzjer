using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace FryzjerManager.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy AmountField.xaml
    /// </summary>
    public partial class AmountField : UserControl
    {
        public AmountField()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent NumberChangedEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected",
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(AmountField));

        //definicja zdarzenia NumberChanged
        public event RoutedEventHandler NumberChanged
        {
            add { AddHandler(NumberChangedEvent, value); }
            remove { RemoveHandler(NumberChangedEvent, value); }
        }

        //Metoda pomocnicza wywołująca zdarzenie
        void RaiseNunberChanged()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(AmountField.NumberChangedEvent);
            RaiseEvent(newEventArgs);
        }


        //Stworzenie wlasnosci zaleznej
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(AmountField), new FrameworkPropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }



        //zdarzenie wywoływane zanim zmianie ulegnie tekst sprawdzajace czy mozna dana zmiane wprowadzic
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string t = ((TextBox)sender).Text;

            if (!int.TryParse( t + e.Text, out _))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseNunberChanged();
        }
    }
}
