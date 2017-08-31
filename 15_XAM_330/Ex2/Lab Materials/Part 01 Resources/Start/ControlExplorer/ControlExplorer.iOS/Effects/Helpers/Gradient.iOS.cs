using System;
using CoreAnimation;
using CoreGraphics;

namespace ControlExplorer.iOS.Effects.Helpers
{
    public static class Gradient
    {
        public static CAGradientLayer GetGradientLayer (CGColor colorTop, CGColor colorBottom, nfloat width, nfloat height)
        {
            var gradLayer = new CAGradientLayer();
            gradLayer.Frame = new CGRect(0, 0, width, height);

            gradLayer.Colors = new CGColor[] { colorTop, colorBottom };
            gradLayer.StartPoint = new CGPoint(0, 0);
            gradLayer.EndPoint = new CGPoint(0, 1);

            return gradLayer;
        }
    }
}