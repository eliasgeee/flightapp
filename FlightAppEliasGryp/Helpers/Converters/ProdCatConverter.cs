using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FlightAppEliasGryp.Helpers.Converters
{
    public sealed class ProdCatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter = null, string language = "")
        {
            return ProdTypeConverter.ConvertFromType(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (Int32.TryParse(value.ToString(), out Int32 n32))
                {
                    return n32;
                }
            }
            return 0;
        }
    }

    public static class ProdTypeConverter
    {
        public static object ConvertFromType(object value)
        {
            if (value.ToString() == "BEVERAGE")
            {
                return ProductType.BEVERAGE;
            }
            else if (value.ToString() == "SNACK")
                return ProductType.SNACK;
            return 0;
        }
    }
}
