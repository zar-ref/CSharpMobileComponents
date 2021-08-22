using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Util.Tint
{
    public class TintImageButton : RoutingEffect
    {
        public Color TintColor { get; private set; }
        public TintImageButton(Color color) : base($"CSMC.{nameof(TintImageButton)}")
        {
            TintColor = color;
        }

    }



}
