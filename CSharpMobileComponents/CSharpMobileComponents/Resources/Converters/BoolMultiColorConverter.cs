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
            Dictionary<string, ColorTheme> colorDictionary = ( Dictionary<string, ColorTheme>) values[0];
            if (colorDictionary == null)
                return Color.Transparent;
            bool  condition = (bool  ) values[1];
            
            var key = (string)parameter;
            if (key == null)
                return Color.Transparent;
            string[] keys = key.Split('.');
            if (keys.Length != 2)
                return Color.Transparent;
            try
            {
                if (ColorsDataStore.Instance.CurrentColorTheme == ColorThemes.DarkTheme.ToString())
                {
                    if (condition)
                        return colorDictionary[keys[0]].DarkThemeColor;
                    else
                        return colorDictionary[keys[1]].DarkThemeColor;
                }
                
                else if (ColorsDataStore.Instance.CurrentColorTheme == ColorThemes.LightTheme.ToString())
                {
                    if (condition)
                        return colorDictionary[keys[0]].LightThemeColor;
                    else
                        return colorDictionary[keys[1]].LightThemeColor;
                }
         
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
