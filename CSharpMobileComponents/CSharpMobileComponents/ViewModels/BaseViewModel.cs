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

        public string CurrentLanguage { get; set; } =  Languages.English.ToString();

        //Key: resource
        //Value: translation
        private static Dictionary<string, string> translations { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Translations
        {
            get
            {
                if (translations == null)
                    translations = new Dictionary<string, string>();
                return translations;
            }
            set
            {

                translations = value;
                OnPropertyChanged("Translations");
            }
        }

        public void ClearTranslations()
        {
            translations.Clear();
        }


        public void RegisterTranslation(string resource)
        {
            var translation = TranslateExtension.GetLanguageResource(resource);
            if (translation == null)
                translations.Add(resource, "Missing Translation");
            var alreadyHasKey = translations.Any(dic => dic.Key == resource);
            if (!alreadyHasKey)
            {
                translations.Add(resource, translation);
                OnPropertyChanged("Translations");
            }

        }

        public void SwitchTranslations()
        {
            var translationkeys = translations.Keys.ToList();
            ClearTranslations();
            CurrentLanguage = LanguagesDataStore.Instance.Language;
            foreach (var resource in translationkeys)
            {
                RegisterTranslation(resource);
            }
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
            
            Binding binding = new Binding("Sizes[" + sizeType + "]"); 
            return binding;
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
