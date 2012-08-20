using System;
using System.Windows;
using System.Windows.Data;

namespace Blackbox
{
    public class PositionToThicknessConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Position position = (Position)value;

            return new Thickness(position.Row * BlackboxConfig.BoxWidth, position.Column * BlackboxConfig.BoxHeight, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
