using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Models.Lists
{
    public class ThemesModel : BaseModel, ISelectableModel
    {
        public string ThemeName { get; set; }
        public  ColorThemes Theme { get; set; }
        public  bool IsSelected { get; set; }
    }
}
