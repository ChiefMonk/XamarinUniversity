using Android.Graphics;
using Android.Graphics.Drawables;

namespace ControlExplorer.Droid.Effects.Helpers
{
    public static class Gradient
    {        
        public static GradientDrawable GetGradientDrawable (Color colorTop, Color colorBottom)
        {
            return new GradientDrawable(GradientDrawable.Orientation.TopBottom, new int[] { colorTop, colorBottom });
        }
    }
}