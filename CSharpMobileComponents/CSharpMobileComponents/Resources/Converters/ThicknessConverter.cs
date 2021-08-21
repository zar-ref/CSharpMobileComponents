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
     public class ThicknessConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var thicknessDictionary = (Dictionary<string, ThicknessModel>)value;
            if (value == null)
                return string.Empty;

            var key = (string)parameter;
            if (key == null)
                return Color.Transparent;
            try
            {
                if (SizesDataStore.Instance.CurrentDeviceType == DeviceTypes.Mobile.ToString())
                    return thicknessDictionary[key].MobileThickness;
                else
                    return thicknessDictionary[key].TabletThickness;

            }
            catch (Exception)
            {

                return 0;
            }






        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();


        }


    }
}
