using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		int _currentState = 1;
		string _mathOperator;
		double _firstNumber, _secondNumber;

		public MainPage()
		{
			InitializeComponent();
			OnClear(this, null);
		}

		private void OnSelectNumber(object sender, EventArgs e)
		{
			var button = (Button)sender;
			var pressed = button.Text;

			if (LblResultText.Text == "0" || _currentState < 0)
			{
				LblResultText.Text = "";
				if (_currentState < 0)
					_currentState *= -1;
			}

			LblResultText.Text += pressed;

			double number;
			if (double.TryParse(LblResultText.Text, out number))
			{
				LblResultText.Text = number.ToString("N0");
				if (_currentState == 1)
				{
					_firstNumber = number;
				}
				else
				{
					_secondNumber = number;
				}
			}
		}

		private void OnSelectOperator(object sender, EventArgs e)
		{
			_currentState = -2;
			var button = (Button)sender;
			var pressed = button.Text;
			_mathOperator = pressed;
		}

		private void OnClear(object sender, EventArgs e)
		{
			_firstNumber = 0;
			_secondNumber = 0;
			_currentState = 1;
			LblResultText.Text = "0";
		}

		private void OnCalculate(object sender, EventArgs e)
		{
			if (_currentState == 2)
			{
				var result = SimpleCalculator.Calculate(_firstNumber, _secondNumber, _mathOperator);

				LblResultText.Text = result.ToString("N0");
				_firstNumber = result;
				_currentState = -1;
			}
		}
	}
}
