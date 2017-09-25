using Android.App;
using Android.Widget;
using Phoneword.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Phoneword.Droid.Services.ToastMessage))]
namespace Phoneword.Droid.Services
{
	public class ToastMessage : IToastMessage
	{
		public void LongAlert(string message)
		{
			Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
		}

		public void ShortAlert(string message)
		{
			Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
		}
	}
}
