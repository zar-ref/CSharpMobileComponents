using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.CustomViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public class GroupedStackLayoutListItem : IGroupKeyStackLayoutListItem
    {
        public object GroupKeyItem { get; set; }
        public ICustomView View { get; set; }
    }
}
