using System;
using System.Windows;
using System.Globalization;
using System.Windows.Data;

namespace HardTrainingCore.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = (bool) value;

            if (isVisible)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visiblity = (Visibility) value;
            bool convertedValue = false;

            switch (visiblity)
            {
                case Visibility.Collapsed:
                case Visibility.Hidden:
                    convertedValue = false;
                    break;
                case Visibility.Visible:
                    convertedValue = true;
                    break;
                default:
                    convertedValue = false;
                    break;
            }

            return convertedValue;
        }
    }
}