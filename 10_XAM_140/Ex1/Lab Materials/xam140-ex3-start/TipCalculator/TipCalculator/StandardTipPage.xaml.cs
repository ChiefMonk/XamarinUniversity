using System;
using Xamarin.Forms;

namespace TipCalculator
{
	public partial class StandardTipPage : ContentPage
	{
		public StandardTipPage()
		{
			InitializeComponent();
			billInput.TextChanged += (s, e) => CalculateTip();
		}

		void CalculateTip()
		{
			double bill;

			if (Double.TryParse(billInput.Text, out bill) && bill > 0)
			{
				double tip   = Math.Round(bill*0.15, 2);
				double final = bill + tip;

				tipOutput  .Text = tip  .ToString("C");
				totalOutput.Text = final.ToString("C");
			}
		}

		void OnLight(object sender, EventArgs e)
		{
			Resources["fgColor"] = Color.FromHex("#606060");
			Resources["bgColor"] = Color.FromHex("#C0C0C0");

			//LayoutRoot.SetDynamicResource(Grid.BackgroundColorProperty, "fgColor");
		}

		void OnDark(object sender, EventArgs e)
		{
			Resources["fgColor"] = Color.FromHex("#C0C0C0");
			Resources["bgColor"] = Color.FromHex("#606060");			
		}

		void GotoCustom(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CustomTipPage());
		}
	}
}

