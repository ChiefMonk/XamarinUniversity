using System;
using Xamarin.Forms;

namespace FirstApp
{
	public partial class App : Application
	{
		public App()
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					new Label
					{
						HorizontalTextAlignment = TextAlignment.Center,
						Text = "Welcome to Xamarin Forms!"
					},
				}
			};

			var button = new Button
			{
				Text = "Click Me!",
				FontSize = 16,
				TextColor = Color.LightBlue,
			};
			button.Clicked += OnButtonClicked;

			MainPage = new NavigationPage(new MainPage
			{
				Content = layout
			});
			

			layout.Children.Add(button);
		}

		private async void OnButtonClicked(object sender, EventArgs e)
		{
			await MainPage.DisplayAlert("Alert", "You Clicked Me!", "Ok");
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
