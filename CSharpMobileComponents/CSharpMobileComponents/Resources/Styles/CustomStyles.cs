using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Styles
{
    public static class CustomStyles
    {
        public static Color GetColorFromName(string colorName)
        {
            Application.Current.Resources.TryGetValue(colorName, out var color);
            if (color != null)
                return (Color)color;
            else
                return Color.Transparent;
        }
    }
}
