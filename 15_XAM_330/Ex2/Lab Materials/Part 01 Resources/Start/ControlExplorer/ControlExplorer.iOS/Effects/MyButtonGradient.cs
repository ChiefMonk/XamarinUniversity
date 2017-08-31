using ControlExplorer.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]

namespace ControlExplorer.iOS.Effects
{

    public class MyButtonGradientEffect : PlatformEffect
    {
        protected override void OnAttached()
        {

        }

        protected override void OnDetached()
        {

        }
    }
}