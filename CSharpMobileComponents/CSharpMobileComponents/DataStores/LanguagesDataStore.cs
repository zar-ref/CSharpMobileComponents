using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CSharpMobileComponents.Resources.Resx;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.DataStores
{
    public class LanguagesDataStore : BaseDataStore
    {
        public override string Name { get; set; } = "LANGUAGES_DATA_STORE";

        public override void CleanDataStore()
        {
            return;
        }

        private static LanguagesDataStore instance = null;
        public static LanguagesDataStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new LanguagesDataStore();
                return instance;
            }
        }

        public string Language { get; set; } = Languages.English.ToString();

        public Dictionary<string, CultureInfo> LanguageDictionary { get; set; } = new Dictionary<string, CultureInfo>
        {
            {  Languages.Portuguese.ToString(), new CultureInfo("pt") },
            { Languages.English.ToString(), new CultureInfo("en") }

        };

        public CultureInfo CurrentAplicationCultureInfo
        {
            get
            {
                return LanguageDictionary[Language];
            }
        }


        public LanguagesDataStore()
        {
            RegistDataStore();
        }

        public void ChangeLanguage(Languages newLanguage)
        {
            if (Language != newLanguage.ToString())
            {
                var newCultureInfo = LanguageDictionary[newLanguage.ToString()];
                CSharpMobileComponents.Resources.Resx.Resources.Culture = newCultureInfo;
                Language = newLanguage.ToString();
            }
        }
    }
}
