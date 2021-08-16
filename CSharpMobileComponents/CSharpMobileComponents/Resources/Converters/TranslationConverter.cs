using CSharpMobileComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Converters
{
    public class TranslationConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var translationDictionary = (Dictionary<string, string>)value;
            if (value == null)
                return string.Empty;

            var key = (string)parameter;
            if (key == null)
                return string.Empty;


            var alreadyHasKey = translationDictionary.Any(dic => dic.Key == key);
            if (alreadyHasKey)
                return translationDictionary[key];


            BaseViewModel vm;
            try
            {
                vm = (BaseViewModel)Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault().BindingContext;
                if (vm == null)
                    return string.Empty;
                vm.RegisterTranslation(key);

                return vm.Translations[key];
            }
            catch (Exception ex) //Page stil does not have binding context
            {

                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}