using FlightAppEliasGryp.Models;
using System;
using Windows.UI.Xaml.Data;

namespace FlightAppEliasGryp.Helpers.Converters
{
    class PromotionTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter = null, string language = "")
        {
            return PromTypeConverter.ConvertFromType(value);
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

    public static class PromTypeConverter
    {
        public static object ConvertFromType(object value)
        {
            if (value.ToString() == "FIXED_PRICE")
                return PromotionType.FIXED_PRICE;
            else if (value.ToString() == "PERCENTAGE")
                return PromotionType.PERCENTAGE;
            else if (value.ToString() == "QUANTITY")
                return PromotionType.QUANTITY;
            return 0;
        }
    }
}
