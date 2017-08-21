using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Alignment.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnHorizontalStartClicked(object sender, EventArgs e)
        {
            LblTarget.HorizontalOptions = LayoutOptions.Start;
        }

        private void OnHorizontalCenterClicked(object sender, EventArgs e)
        {
            LblTarget.HorizontalOptions = LayoutOptions.Center;
        }

        private void OnHorizontalEndClicked(object sender, EventArgs e)
        {
            LblTarget.HorizontalOptions = LayoutOptions.End;
        }

        private void OnHorizontalFillClicked(object sender, EventArgs e)
        {
            LblTarget.HorizontalOptions = LayoutOptions.Fill;
        }

        private void OnVerticalStartClicked(object sender, EventArgs e)
        {
            LblTarget.VerticalOptions = LayoutOptions.Start;
        }

        private void OnVerticalCenterClicked(object sender, EventArgs e)
        {
            LblTarget.VerticalOptions = LayoutOptions.Center;
        }

        private void OnVerticalEndClicked(object sender, EventArgs e)
        {
            LblTarget.VerticalOptions = LayoutOptions.End;
        }

        private void OnVerticalFillClicked(object sender, EventArgs e)
        {
            LblTarget.VerticalOptions = LayoutOptions.Fill;
        }
    }
}