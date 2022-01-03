using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Controls.Interfaces
{
    public interface IBaseCustomButton
    {

        ICommand Command { get; set; }
        object CommandParameter { get; set; }
        string DisplayText { get; set; }
    }

}
