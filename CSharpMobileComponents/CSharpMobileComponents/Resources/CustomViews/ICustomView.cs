using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Resources.CustomViews
{
    public interface ICustomView
    {
        void SetViewBindings();
        void SetBindingContext(object bindingContext);
        int? ListIndex { get; set; }
    }
}
