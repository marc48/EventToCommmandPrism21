using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Windows.UI.Xaml;   // added for sizechangedEventArgs
using Xamarin.Forms;

namespace MyEventComPrism21.Converters
{
    public class SizeChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SizeChangedEventArgs sizeChangedEventArgs))
            {
                throw new ArgumentException("Expected value to be of type SizeChangedEventArgs", nameof(value));
            }

            return sizeChangedEventArgs.ToString();   // NewSize;   // Struktur height/width
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
