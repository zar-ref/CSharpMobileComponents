using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Controls.Interfaces
{
    public interface ISelectableList
    {
        bool HasMultipleSelections { get; set; }
        void HandleItemTapped(object sender, ItemTappedEventArgs e);
    }
}
