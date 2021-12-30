using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CSharpMobileComponents.Resources.Controls.Interfaces
{
    public interface IStackLayoutListItem
    {
        object Item { get; set; }
        ICustomView View { get; set; }
        object GroupKey { get; set; }
        bool IsGroupingHeader { get; set; }
        ICommand OnItemTappedCommand { get; set; }
        object ItemTappedCommandParameter { get; set; }
        double? MaxHeight { get; set; }  

    }
}
