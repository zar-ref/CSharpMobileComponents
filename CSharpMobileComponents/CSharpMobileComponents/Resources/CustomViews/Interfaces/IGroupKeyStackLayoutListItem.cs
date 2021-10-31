using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Resources.CustomViews.Interfaces
{
    public interface IGroupKeyStackLayoutListItem
    {

        object GroupKeyItem { get; set; }
        ICustomView View { get; set; } 
    }
}
