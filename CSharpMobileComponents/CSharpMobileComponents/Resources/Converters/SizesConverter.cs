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
    class SizesConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sizeDictionary = (Dictionary<string, DeviceSizes>)value;
            if (value == null)
                return string.Empty;

            var key = (string)parameter;
            if (key == null)
                return 1;

            if (SizesDataStore.Instance.CurrentDeviceType == DeviceTypes.Mobile.ToString())
                return sizeDictionary[key].MobileSize;
            else
                return sizeDictionary[key].TabletSize;





        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();


        }


    }
}
