using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Converters
{
    public class BoolMultiColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Color color = (Color)values[1];
                if (color == null)
                    return Color.Transparent;
                bool condition = (bool)values[0];
                if (condition)
                    return color;
                else
                    return Color.Transparent;
            }
            catch (Exception)
            {

                return Color.Transparent;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
