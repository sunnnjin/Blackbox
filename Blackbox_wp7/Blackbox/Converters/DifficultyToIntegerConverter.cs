using System;
using System.Windows.Data;

namespace Blackbox
{
    public class DifficultyToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int difficultyInteger = -1;

            if (value is DifficultyType)
            {
                difficultyInteger = (int)value;
            }

            return difficultyInteger;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DifficultyType difficultyType = DifficultyType.Easy;

            if (value is int)
            {
                difficultyType = (DifficultyType)value;
            }

            return difficultyType;
        }
    }
}
