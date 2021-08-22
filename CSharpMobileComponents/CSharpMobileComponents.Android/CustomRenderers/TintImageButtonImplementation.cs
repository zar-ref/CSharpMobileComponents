using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CSharpMobileComponents.Droid.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
 


[assembly: ExportEffect(typeof(TintImageButtonImplementation), nameof(CSharpMobileComponents.Resources.Util.Tint.TintImageButton))]
namespace CSharpMobileComponents.Droid.CustomRenderers
{
    public class TintImageButtonImplementation:PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (CSharpMobileComponents.Resources.Util.Tint.TintImageButton)Element.Effects.FirstOrDefault(e => e is CSharpMobileComponents.Resources.Util.Tint.TintImageButton);

                if (effect == null || !(Control is Android.Widget.ImageButton image))
                    return;

                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDetached() { }
    }
}