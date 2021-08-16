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
    public class ColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorDictionary = (Dictionary<string, ColorTheme>)value;
            if (value == null)
                return string.Empty;

            var key = (string)parameter;
            if (key == null)
                return Color.Transparent;

            if (ColorsDataStore.Instance.CurrentColorTheme == ColorThemes.DarkTheme.ToString())
                return colorDictionary[key].DarkThemeColor;
            else if (ColorsDataStore.Instance.CurrentColorTheme == ColorThemes.LightTheme.ToString())
                return colorDictionary[key].LightThemeColor;
            else
                return Color.Transparent;





        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();


        }


    }

}
