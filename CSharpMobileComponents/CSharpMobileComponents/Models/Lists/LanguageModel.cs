using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Models.Lists
{
    public class LanguageModel: BaseModel, ISelectableModel, IDisplayTextModel
    {
        public bool isSelected { get; set; }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string displayText { get; set; }

        public string DisplayText
        {
            get
            {
                return displayText;
            }
            set
            {
                displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        public Languages Language { get; set; }
    }
}
