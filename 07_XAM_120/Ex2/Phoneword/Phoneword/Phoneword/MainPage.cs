using System;
using Phoneword.Services;
using Xamarin.Forms;

namespace Phoneword
{
	public class MainPage : ContentPage
	{
		private Label _lblEntry;
		private Entry _entryText;
		private Button _btnTranslate;
		private Button _btnCall;
		private string _translatedNumber;		

		public MainPage()
		{						
			Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);
			
			//Layout
			var layout = new StackLayout
			{
				Spacing = 15,
				Orientation = StackOrientation.Vertical 
			};

			_lblEntry = new Label()
			{
				Text = "Enter a Phoneword",
			};
			layout.Children.Add(_lblEntry);

			_entryText = new Entry()
			{
				Placeholder = "Enter a Phoneword",
				Text = "1-855-XAMARIN",
			};
			_entryText.TextChanged += OnEntryTextChangedClicked;
			layout.Children.Add(_entryText);

			_btnTranslate = new Button()
			{
				Text = "Translate",
			};
			_btnTranslate.Clicked += OnTranslateButtonClicked;
			layout.Children.Add(_btnTranslate);

			_btnCall = new Button()
			{
				Text = "Call",
				IsEnabled = false,
			};
			_btnCall.Clicked += OnCallButtonClicked;
			layout.Children.Add(_btnCall);

			this.Content = layout;			
		}

		private void OnEntryTextChangedClicked(object sender, EventArgs e)
		{

		}

		private void OnTranslateButtonClicked(object sender, EventArgs e)
		{
			var input = _entryText.Text;
			_btnCall.Text = "Call";
			_btnCall.IsEnabled = false;

			if (string.IsNullOrWhiteSpace(input))
			{
				DependencyService.Get<IToastMessage>().LongAlert("Please enter a valid phoneword to translate!");
				return;
			}

			_translatedNumber = PhonewordTranslator.ToNumber(input);

			if (string.IsNullOrWhiteSpace(_translatedNumber))
			{				
				DependencyService.Get<IToastMessage>()
					.ShortAlert($"Unable to translate the input text '{input}'");
			}
			else
			{
				_btnCall.Text = $"Call {_translatedNumber}";
				_btnCall.IsEnabled = true;

				DependencyService.Get<IToastMessage>()
					.ShortAlert($"{input} has been successfully translated to {_translatedNumber}");
			}			
		}

		private async void OnCallButtonClicked(object sender, EventArgs e)
		{
			var result = await DisplayAlert("Dial a Number", $"Would you like to call {_translatedNumber}?", "Yes", "No");

			var osType = "Other";
			var idiom = "Other";

			switch (Device.OS)
			{
					case TargetPlatform.Android:
						osType = "Android";
					break;

				case TargetPlatform.WinPhone:
					osType = "WinPhone";
					break;

				case TargetPlatform.iOS:
					osType = "iOS";
					break;
			}

			switch (Device.Idiom)
			{
				case TargetIdiom.Phone:
					idiom = "Phone";
					break;

				case TargetIdiom.Desktop:
					idiom = "Desktop";
					break;

				case TargetIdiom.Tablet:
					idiom = "Tablet";
					break;
			}

			if (result)
			{
				var dialer = DependencyService.Get<IPhoneDialer>();

				if (dialer != null)
				{
					if (await dialer.DialNumberAsync(_translatedNumber))
					{
						DependencyService.Get<IToastMessage>()
							.ShortAlert($"{_translatedNumber} has been dialled on a {idiom} running on a {osType}");
					}
				}

				
			}
			
		}
	}
}