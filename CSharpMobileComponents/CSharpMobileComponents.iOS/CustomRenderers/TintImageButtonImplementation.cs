using CSharpMobileComponents.iOS.CustomRenderers;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(TintImageButtonImplementation), nameof(CSharpMobileComponents.Resources.Util.Tint.TintImageButton))]
namespace CSharpMobileComponents.iOS.CustomRenderers
{
    public class TintImageButtonImplementation : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (CSharpMobileComponents.Resources.Util.Tint.TintImageButton)Element.Effects.FirstOrDefault(e => e is CSharpMobileComponents.Resources.Util.Tint.TintImageButton);

                if (effect == null || !(Control is UIButton imageButton))
                    return;

                imageButton.ImageView.Image = imageButton.ImageView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                imageButton.ImageView.TintColor = effect.TintColor.ToUIColor();
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnDetached() { }
    }
}