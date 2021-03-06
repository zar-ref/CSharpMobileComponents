using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public class StackLayoutListItem : IStackLayoutListItem
    {
        public object Item { get; set; }
        public ICustomView View { get; set; }
        public object GroupKey { get; set; }
        public ICommand OnItemTappedCommand { get; set; }
        public object ItemTappedCommandParameter { get; set; }
        public bool IsGroupingHeader { get; set; } = false;
        public double? MaxHeight { get; set; }
    }
}
