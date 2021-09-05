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

        public string CurrentColorTheme { get; set; } = ColorThemes.DarkTheme.ToString();
        public List<ColorThemes> AvailableColorThemes { get; set; } = new List<ColorThemes>
        {
            {ColorThemes.LightTheme },
            {ColorThemes.DarkTheme }
        };

        /// <summary>
        /// Key: Color Type
        /// Value: Current color theme's color
        /// </summary>
        public Dictionary<string, ColorTheme> Colors { get; set; }

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


        private void FillColorsDictionary()
        {
            Colors = new Dictionary<string, ColorTheme>();
            Colors.Add(ColorTypes.Background.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.DarkDark.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.LightLight.ToString())
            });
            Colors.Add(ColorTypes.Text.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.LightLight.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.DarkDark.ToString())
            });
            Colors.Add(ColorTypes.SecondaryButtonTextColor.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.Primary.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.DarkDark.ToString())
            });
            Colors.Add(ColorTypes.SecondaryButtonBackgroundColor.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.DarkDark.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.Light.ToString())
            });
            Colors.Add(ColorTypes.PrimaryButtonBackgroundColor.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.Primary.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.PrimaryLight.ToString())
            });
            Colors.Add(ColorTypes.PrimaryButtonTextColor.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.DarkDark.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.PrimaryLight.ToString())
            });
            Colors.Add(ColorTypes.GradeOut.ToString(), new ColorTheme()
            {
                DarkThemeColor = CustomStyles.GetColorFromName(ColorNames.LightDark.ToString()),
                LightThemeColor = CustomStyles.GetColorFromName(ColorNames.Dark.ToString())
            });

        }

        public void ChangeCurrentColorTheme(ColorThemes colorTheme)
        {
            CurrentColorTheme = colorTheme.ToString();

        }

    }
}
