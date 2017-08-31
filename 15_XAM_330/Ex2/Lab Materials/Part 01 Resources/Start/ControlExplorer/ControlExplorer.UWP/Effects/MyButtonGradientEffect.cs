using System;
using ControlExplorer.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]

namespace ControlExplorer.UWP.Effects
{
   
    public class MyButtonGradientEffect: PlatformEffect
    {
        protected override void OnAttached()
        {
           
        }

        protected override void OnDetached()
        {
           
        }
    }
}