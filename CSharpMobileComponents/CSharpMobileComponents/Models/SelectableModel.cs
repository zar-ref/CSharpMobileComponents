using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public class SelectableModel : BaseModel
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
    }
}
