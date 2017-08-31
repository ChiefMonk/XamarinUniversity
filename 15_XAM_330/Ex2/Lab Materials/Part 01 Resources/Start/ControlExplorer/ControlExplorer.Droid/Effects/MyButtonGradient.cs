using Android.Graphics.Drawables;
using ControlExplorer.Droid.Effects;
using ControlExplorer.Droid.Effects.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]

namespace ControlExplorer.Droid.Effects
{

    public class MyButtonGradientEffect : PlatformEffect
    {

        private Drawable _oldDrawable;

        protected override void OnAttached()
        {
            if(!(Element is Button))
                return;

            _oldDrawable = Control.Background;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if(_oldDrawable != null)
                Control.SetBackground(_oldDrawable);
        }

        private void SetGradient()
        {
            var button = Element as Button;

            if (button != null)
            {
                var xfButton = button;
                var colorTop = xfButton.BackgroundColor;
                var colorBottom = Xamarin.Forms.Color.Black;                

                var drawable = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());
                Control.SetBackground(drawable);
            }
        }
    }
}