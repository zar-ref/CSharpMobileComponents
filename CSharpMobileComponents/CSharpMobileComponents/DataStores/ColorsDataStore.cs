using CSharpMobileComponents.Models;
using CSharpMobileComponents.Resources.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.DataStores
{
    public class ColorsDataStore : BaseDataStore
    {
        public override string Name { get; set; } = "COLORS_DATA_STORE";

        public override void CleanDataStore()
        {
            return;
        }

        private static ColorsDataStore instance = null;
        public static ColorsDataStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new ColorsDataStore();
                return instance;
            }
        }

        public ColorsDataStore()
        {
            RegistDataStore();
            FillColorsDictionary();
        }



        /// <summary>
        /// Key: Color Type
        /// Value: Current color theme's color
        /// </summary>
        public Dictionary<string, ColorTheme> Colors { get; set; }

        private void FillColorsDictionary()
        {
            Colors = new Dictionary<string, ColorTheme>();
            Colors.Add(ColorTypes.Background.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.Dark.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.Light.ToString())
            });

        }
    }
}
