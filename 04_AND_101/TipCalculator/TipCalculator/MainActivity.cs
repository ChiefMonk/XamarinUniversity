using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
	[Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{		
		private Button _btnCalculate;
		private EditText _inputBill;
		private TextView _outputTip;
		private TextView _outputTotal;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//inputBill
			_inputBill = FindViewById<EditText>(Resource.Id.inputBill);

			// btnCalculate
			_btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
			_btnCalculate.Click += OnButtonClicked;

			//outputTip
			_outputTip = FindViewById<TextView>(Resource.Id.outputTip);

			//_outputTotal
			_outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
		}

		protected void OnButtonClicked(object sender, System.EventArgs e)
		{
			double billAmount;
			if (double.TryParse(_inputBill.Text, out billAmount))
			{
				var tipAmount = billAmount * 0.15;
				var totalAmount = billAmount + tipAmount;

				_outputTip.Text = tipAmount.ToString("0.00#");
				_outputTotal.Text = totalAmount.ToString("0.00#");
			}
		}
	}
}

