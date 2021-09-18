using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Resources
{
    public class Constants
    {
        public enum Languages
        {

            English,
            Portuguese
        }

        public enum ColorThemes
        {
            LightTheme,
            DarkTheme
        }

        public enum ColorNames
        {
            PrimaryDark,
            PrimaryDarkContrast,
            Primary,
            PrimaryContrast,
            PrimaryLight,
            PrimaryLightContrast,
            PrimaryAccent,
            PrimaryAccentContrast,

            SecondaryDark,
            SecondaryDarkContrast,
            Secondary,
            SecondaryContrast,
            SecondaryLight,
            SecondaryLightContrast,
            SecondaryAccent,
            SecondaryAccentContrast,

            TertiaryDark,
            TertiaryDarkContrast,
            Tertiary,
            TertiaryContrast,
            TertiaryLight,
            TertiaryLightContrast,
            TertiaryAccent,
            TertiaryAccentContrast,

            DarkDark,
            DarkDarkContrast,
            Dark,
            DarkContrast,
            DarkLight,
            DarkLightContrast,
            DarkAccent,
            DarkAccentContrast,

            LightDark,
            LightDarkContrast,
            Light,
            LightContrast,
            LightLight,
            LightLightContrast,
            LightAccent,
            LightAccentContrast
        }

        public enum ColorTypes
        {

            Background,
            Text,
            GradeOut,
            PrimaryButtonBorder,
            SecondaryButtonTextColor,
            PrimaryButtonBackgroundColor,
            SecondaryButtonBackgroundColor,
            PrimaryButtonTextColor,
            ListViewSelectedItem,
            RadioButton
        }

        public enum DeviceTypes
        {
            Mobile,
            Tablet
        }


        public enum AppDeviceSizes
        {
            Small,
            Body,
            H1,
            H2,
            H3,
            H4,

            Tile,

            ButtonControlHeight,
            PrimaryOrSecondaryButtonControlCornerRadius,
            PrimaryOrSecondaryButtonControlWidth,
            OutterRadioButton,
            OutterRadioButtonCornerRadius,
            InnerRadioButton,
            InnerRadioButtonCornerRadius,
            GridRadioButtonWidthContainer


        }

        public enum AppDeviceThicknesses
        {
            ModalMargin,
            SecondaryButtonMargin,
            SecondaryButtonPadding,
            MarginTop_1,
            MarginTop_2,
            MarginTop_3,
            MarginTop_4,
        }

        public enum SelectableListTypes
        {
            Radio,
            Check
        }

        public enum CustomControlsMessagesNames
        {
            Register,
            UnsubscribeOnDisappearing

        }

    }
}
