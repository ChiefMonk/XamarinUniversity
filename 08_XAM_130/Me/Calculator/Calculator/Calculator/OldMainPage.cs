using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Utils;
using Xamarin.Forms;

namespace Calculator
{
	public class OldMainPage : ContentPage
	{
		private Label _resultText;
		private int _currentState = 1;
		private string _mathOperator;
		private double _firstNumber, _secondNumber;

		public OldMainPage()
		{
			Grid layout = new Grid
			{
				Padding = new Thickness(5, 0),
				RowSpacing = 1,
				ColumnSpacing = 1,
				BackgroundColor = Color.Black,
			};

			// Setup the grid 4x6
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			this._resultText = new Label
			{
				FontSize = 48,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.NoWrap,
			};
			Grid.SetColumnSpan(this._resultText, 4);
			layout.Children.Add(this._resultText);

			// Create the numbers.
			layout.Children.Add(CreateNumberButton("7", 1, 0));
			layout.Children.Add(CreateNumberButton("8", 1, 1));
			layout.Children.Add(CreateNumberButton("9", 1, 2));
			layout.Children.Add(CreateNumberButton("4", 2, 0));
			layout.Children.Add(CreateNumberButton("5", 2, 1));
			layout.Children.Add(CreateNumberButton("6", 2, 2));
			layout.Children.Add(CreateNumberButton("1", 3, 0));
			layout.Children.Add(CreateNumberButton("2", 3, 1));
			layout.Children.Add(CreateNumberButton("3", 3, 2));
			Button zero = CreateNumberButton("0", 4, 0);
			Grid.SetColumnSpan(zero, 3);
			layout.Children.Add(zero);

			// Create the operators
			layout.Children.Add(CreateOperatorButton("/", 1));
			layout.Children.Add(CreateOperatorButton("X", 2));
			layout.Children.Add(CreateOperatorButton("-", 3));
			layout.Children.Add(CreateOperatorButton("+", 4));

			// Create the clear button.
			Button clear = new Button()
			{
				Text = "C",
				BackgroundColor = Color.FromRgb(0x80, 0x80, 0x80),
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(36),
				BorderRadius = 0,
			};
			Grid.SetRow(clear, 5);
			clear.Clicked += OnClear;
			layout.Children.Add(clear);

			// And the equals.
			Button equals = new Button()
			{
				Text = "=",
				BackgroundColor = Color.FromHex("#FFA500"),
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(36),
				BorderRadius = 0,
			};
			Grid.SetRow(equals, 5);
			Grid.SetColumn(equals, 1);
			Grid.SetColumnSpan(equals, 3);
			equals.Clicked += OnCalculate;
			layout.Children.Add(equals);

			OnClear(null, EventArgs.Empty);
			Content = layout;
		}

		Button CreateOperatorButton(string str, int row)
		{
			Button button = new Button()
			{
				Text = str,
				BackgroundColor = Color.FromHex("#FFA500"),
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(36),
				BorderRadius = 0,
			};
			Grid.SetRow(button, row);
			Grid.SetColumn(button, 3);
			button.Clicked += OnSelectOperator;
			return button;
		}

		Button CreateNumberButton(string str, int row, int col)
		{
			Button button = new Button()
			{
				Text = str,
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				Font = Font.SystemFontOfSize(36),
				BorderRadius = 0,
			};
			Grid.SetRow(button, row);
			Grid.SetColumn(button, col);
			button.Clicked += OnSelectNumber;
			return button;
		}

		protected void OnSelectNumber(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string pressed = button.Text;

			if (this._resultText.Text == "0" || _currentState < 0)
			{
				this._resultText.Text = "";
				if (_currentState < 0)
					_currentState *= -1;
			}

			this._resultText.Text += pressed;

			double number;
			if (double.TryParse(this._resultText.Text, out number))
			{
				this._resultText.Text = number.ToString("N0");
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
			Button button = (Button)sender;
			string pressed = button.Text;
			_mathOperator = pressed;
		}

		protected void OnClear(object sender, EventArgs e)
		{
			_firstNumber = 0;
			_secondNumber = 0;
			_currentState = 1;
			this._resultText.Text = "0";
		}

		protected void OnCalculate(object sender, EventArgs e)
		{
			if (_currentState == 2)
			{
				var result = SimpleCalculator.Calculate(_firstNumber, _secondNumber, _mathOperator);

				this._resultText.Text = Math.Round(result, 5).ToString(); //.ToString("N0");
				_firstNumber = result;
				_currentState = -1;
			}
		}
	}
}