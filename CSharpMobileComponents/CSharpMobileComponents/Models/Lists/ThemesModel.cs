
using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Models.Lists
{
    public class ThemesModel : BaseModel, ISelectableModel, IDisplayTextModel
    {
        private bool isSelected { get; set; }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }

            }
        }

        private string displayText { get; set; }

        public string DisplayText
        {
            get
            {
                return displayText;
            }
            set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }

            }
        }
        public ColorThemes Theme { get; set; }
    }
}
