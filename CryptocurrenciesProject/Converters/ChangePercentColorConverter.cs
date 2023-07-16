using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptocurrenciesProject.Converters
{
    public class ChangePercentColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is decimal changePercent && values[1] is SolidColorBrush defaultBrush)
            {
                if (changePercent < 0)
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.Green;
                }
            }

            return Brushes.Black; // Используем переданный кисть по умолчанию
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
