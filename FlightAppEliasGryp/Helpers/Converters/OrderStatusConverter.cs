using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FlightAppEliasGryp.Helpers.Converters
{
    public sealed class OrderStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter = null, string language = "")
        {
            return OrderStatusConverterHelper.ConvertFromType(value);
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

    public static class OrderStatusConverterHelper
    {
        public static object ConvertFromType(object value)
        {
            if (value.ToString() == "NEW")
            {
                return OrderStatus.NEW;
            }
            else if (value.ToString() == "PENDING")
                return OrderStatus.PENDING;
            else if (value.ToString() == "COMPLETED")
                return OrderStatus.COMPLETED;
            return 0;
        }
    }
}
