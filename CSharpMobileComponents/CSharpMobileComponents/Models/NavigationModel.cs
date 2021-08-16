using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public  class NavigationModel
    {
        public string PageName { get; set; }
        public object PageParameters { get; set; } = new { };
        public Type PageViewModel { get; set; }
        public object PageViewModelParameters { get; set; } = new { };
    }
}
