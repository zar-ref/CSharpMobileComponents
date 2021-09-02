using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Models.Lists
{
    public class ThemesModel : SelectableModel
    {
        public string ThemeName { get; set; }
        public  ColorThemes Theme { get; set; } 
    }
}
