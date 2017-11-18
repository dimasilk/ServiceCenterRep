using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.OrderModule.Converters
{
    public class PriceListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            var collection = (IEnumerable<PricelistDTO>)value;
            if(collection != null) result = String.Join(", ", collection.Select(x => x.Name));
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
