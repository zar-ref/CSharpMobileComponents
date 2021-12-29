using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models.Lists
{
    public class GroupingTestModel : BaseModel, ISelectableModel, IDisplayTextModel //, IComparable
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
                displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        private string groupText { get; set; }

        public string GroupText
        {
            get
            {
                return groupText;
            }
            set
            {
                groupText = value;
                OnPropertyChanged("GroupText");
            }
        }






        private void GenerateGroupKeyDisplayText()
        {
            var groupkey = DisplayText.Split('_')[1];
            GroupText = groupkey;
        }

        //public int CompareTo(object obj)
        //{
        //    if (obj.GetType() != this.GetType())
        //        return -1;
        //    else
        //        return this.DisplayText == ( obj  as GroupingTestModel ).DisplayText ? 0 : -1 ;
        //}

         
        public GroupingTestModel(string displayText)
        { 
            DisplayText = displayText;
            GenerateGroupKeyDisplayText();
        }
    }
}
