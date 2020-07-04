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
        //przy okazji metoda ta tworzy obiekt argument przekazywany przez to zdarzenie
        void RaiseNunberChanged()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(AmountField.NumberChangedEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }


        //zarejestrowanie własności zależenej - taki mechanizm konieczny jest
        // aby możliwe było Bindowanie tej właśności z innnymi obiektami
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(AmountField),
                new FrameworkPropertyMetadata(null)
            );
        //"czysta" właściwość powiązania z właściwości zależną
        //do niej będziemy się odnosić w XAMLU
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }



        //zdarzenie wywoływane zanim zmianie ulegnie tekst textBox-a
        //e.Text  - string zawierający ostatnio dopisany znakm jeszcze niedodany do 
        //własności Text obiektu textBox
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
            //przy każdej zmianie tekstu w polu textBox
            //wyrzucamy zdarzenie, które informuje o tym,
            //że zmieniła się liczba
            RaiseNunberChanged();
        }
    }
}
