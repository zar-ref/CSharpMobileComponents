using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Util.Tint
{
   public  class TintImage: RoutingEffect
    {

        public Color TintColor { get; private set; }
        public TintImage(Color color) : base($"CSMC.{nameof(TintImage)}")
        {
            TintColor = color;
        }
    }
}
