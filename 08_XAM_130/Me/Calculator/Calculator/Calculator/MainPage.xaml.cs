using System;
using Calculator.Utils;
using Xamarin.Forms;

namespace Calculator
{
	public partial class MainPage : ContentPage
	{		
		private int _currentState = 1;
		private string _mathOperator;
		private double _firstNumber, _secondNumber;

		public MainPage()
		{
			InitializeComponent();
			OnClear(null, null);
		}

		protected void OnSelectNumber(object sender, EventArgs e)
		{
			var button = (Button)sender;
			var pressed = button.Text;

			if (LblResultText.Text.Equals("0") || _currentState < 0)
			{
				LblResultText.Text = "";
				if (_currentState < 0)
					_currentState *= -1;
			}

			LblResultText.Text += pressed;

			double number;
			if (double.TryParse(this.LblResultText.Text, out number))
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

		protected void OnSelectOperator(object sender, EventArgs e)
		{
			_currentState = -2;
			var button = (Button)sender;
			var pressed = button.Text;
			_mathOperator = pressed;
		}

		protected void OnClear(object sender, EventArgs e)
		{
			_firstNumber = 0;
			_secondNumber = 0;
			_currentState = 1;
			LblOperationText.Text = "";
			LblResultText.Text = "0";
		}

		protected void OnCalculate(object sender, EventArgs e)
		{
			if (_currentState == 2)
			{
				var result = SimpleCalculator.Calculate(_firstNumber, _secondNumber, _mathOperator);

				LblResultText.Text = $" = {Math.Round(result, 5).ToString()}"; //.ToString("N0");

				LblOperationText.Text = $"{_firstNumber} {_mathOperator} {_secondNumber}";
				_firstNumber = result;
				_currentState = -1;
			}
		}
	}
}
