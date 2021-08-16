using CSharpMobileComponents.DataStores;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Resx
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {


        const string ResourcePath = "CSharpMobileComponents.Resources.Resources";
        public string Text { get; set; }

        internal static string GetLanguageResource(string item)
        {
            ResourceManager resourceManager = new ResourceManager(ResourcePath, typeof(TranslateExtension).GetTypeInfo().Assembly);

            var ci = Languages.Portuguese.ToString().Equals(LanguagesDataStore.Instance.Language)
                ? new CultureInfo("pt")
                : new CultureInfo("en");


            return resourceManager.GetString(item, ci);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;
            ResourceManager resourceManager = new ResourceManager(ResourcePath, typeof(TranslateExtension).GetTypeInfo().Assembly);

            var ci = Languages.Portuguese.ToString().Equals(LanguagesDataStore.Instance.Language)
                ? new CultureInfo("pt")
                : new CultureInfo("en");


            return resourceManager.GetString(Text, ci);
        }


    }
}
