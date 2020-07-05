using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace FryzjerManager.ViewModel
{
    //Konwerter potrzebny do prawidlowego dzialania userControl "AmountField"
    class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "") return null;
            if (int.TryParse(value.ToString(), out _))
            {
                return System.Convert.ToInt32(value.ToString(), CultureInfo.CurrentCulture);
            }
            return null;
        }
    }
}
