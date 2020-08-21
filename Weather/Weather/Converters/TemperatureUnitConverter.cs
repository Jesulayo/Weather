using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Weather.Converters
{
    public class TemperatureUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var test = (double)value;
            if (test == 0)
            {
                return test + " °C";
            }
            else
            {
                test -= 273.15;
                var result = Math.Round(test, 2);
                return result + " °C";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
