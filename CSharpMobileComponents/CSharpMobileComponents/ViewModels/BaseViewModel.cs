using CSharpMobileComponents.DataStores;
using CSharpMobileComponents.Models;
using CSharpMobileComponents.Resources.Converters;
using CSharpMobileComponents.Resources.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isLoading = false;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public string CurrentLanguage { get; set; } = LanguagesDataStore.Instance.Language;

        //Key: resource
        //Value: translation

        public Dictionary<string, string> Translations
        {
            get
            {
                return LanguagesDataStore.Instance.Translations;
            }

        }


        public void SwitchTranslations(Languages newLanguage)
        {
            CurrentLanguage = LanguagesDataStore.Instance.Language;
            LanguagesDataStore.Instance.ChangeLanguage(newLanguage);


            OnPropertyChanged("Translations");

        }

        public static Binding GetTranslationBindingFromResource(string resource)
        {
            var converter = new TranslationConverter();
            Binding binding = new Binding("Translations");
            binding.Converter = converter;
            binding.ConverterParameter = resource;
            return binding;
        }

        public Dictionary<string, ColorTheme> Colors { get { return ColorsDataStore.Instance.Colors; } }

        public static Binding GetColorBindingFromColor(ColorTypes color)
        {
            var converter = new ColorConverter();
            Binding binding = new Binding("Colors");
            binding.Converter = converter;
            binding.ConverterParameter = color.ToString();
            return binding;
        }
        public void SwitchColorTheme()
        {
            if (ColorsDataStore.Instance.CurrentColorTheme == ColorThemes.DarkTheme.ToString())
                ColorsDataStore.Instance.CurrentColorTheme = ColorThemes.LightTheme.ToString();
            else
                ColorsDataStore.Instance.CurrentColorTheme = ColorThemes.DarkTheme.ToString();
            OnPropertyChanged("Colors");
        }
        public Dictionary<string, DeviceSizes> Sizes { get { return SizesDataStore.Instance.Sizes; } }
        public static Binding GetSizeBindingFromSizeType(AppDeviceSizes sizeType)
        {
            var converter = new SizesConverter();
            Binding binding = new Binding("Sizes");
            binding.Converter = converter;
            binding.ConverterParameter = sizeType.ToString();
            return binding;
        }

        public Dictionary<string, ThicknessModel> Thicknesses { get { return SizesDataStore.Instance.Thicknesses; } }
        public static Binding GetSizeBindingFromThicknessType(AppDeviceThicknesses thicknessType)
        {
            var converter = new ThicknessConverter();
            Binding binding = new Binding("Thicknesses");
            binding.Converter = converter;
            binding.ConverterParameter = thicknessType.ToString();
            return binding;
        }

        public Task<bool> BeginInvokeOnMainThreadAsync(Func<Task> task)
        {
            var tcs = new TaskCompletionSource<bool>();
          
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsLoading = true;
                    await task();
                    tcs.SetResult(true);
                    IsLoading = false;
                }
                catch (Exception ex)
                {
                    IsLoading = false;
                    tcs.SetException(ex);
                }
            });
            IsLoading = false;
            return tcs.Task;
        }

        public Task<object> BeginInvokeOnMainThreadAsync(Func<Task<object>> task)
        {
            var tcs = new TaskCompletionSource<object>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsLoading = true;
                    var retVal = await task();
                    tcs.SetResult(retVal);
                    IsLoading = false;
                }
                catch (Exception ex)
                {
                    IsLoading = false;
                    tcs.SetException(ex);
                }
            });
            IsLoading = false;
            return tcs.Task;
        }




        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
