using Windows.UI.Xaml.Controls;
using ControlExplorer.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyCustomFontEffect), "CustomFontEffect")]
namespace ControlExplorer.UWP.Effects
{
    class MyCustomFontEffect : PlatformEffect
    {
        Windows.UI.Xaml.Media.FontFamily oldFontFamily;
        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;

            TextBlock tb = Control as TextBlock;

            oldFontFamily = tb.FontFamily;

            tb.FontFamily = new Windows.UI.Xaml.Media.FontFamily(@"/Assets/Pacifico.ttf#Pacifico");
        }

        protected override void OnDetached()
        {
            if (oldFontFamily != null)
            {
                TextBlock tb = Control as TextBlock;
                tb.FontFamily = oldFontFamily;
            }
        }
    }
}
