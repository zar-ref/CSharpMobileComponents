using System;
using System.Collections.Generic;
using System.Text;
using static CSharpMobileComponents.Pages.BaseNavigationPage;

namespace CSharpMobileComponents.Resources.Controls.Interfaces
{
    public interface ICustomControl
    {
        int ControlHashCode { get; set; }
        int PageHashCode { get; set; }
        void RegisterControl();
        void UnsubscribeOnDisappearing();
        

    }
}
