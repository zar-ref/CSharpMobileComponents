using CSharpMobileComponents.iOS.CustomRenderers;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CSMC")]
[assembly: ExportEffect(typeof(TintImageImplementation), nameof(CSharpMobileComponents.Resources.Util.Tint.TintImage))]
namespace CSharpMobileComponents.iOS.CustomRenderers
{
    public class TintImageImplementation: PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (CSharpMobileComponents.Resources.Util.Tint.TintImage)Element.Effects.FirstOrDefault(e => e is CSharpMobileComponents.Resources.Util.Tint.TintImage);

                if (effect == null || !(Control is UIImageView image))
                    return;

                image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                image.TintColor = effect.TintColor.ToUIColor();
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnDetached() { }
    }
}