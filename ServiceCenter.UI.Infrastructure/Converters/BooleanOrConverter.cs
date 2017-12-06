using System;
using System.Linq;
using System.Windows.Data;

namespace ServiceCenter.UI.Infrastructure.Converters
{
    public class BooleanOrConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var temp = values.OfType<bool>().Any(value => value);
            return parameter != null && parameter.ToString() == "not" ? !temp : temp;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
