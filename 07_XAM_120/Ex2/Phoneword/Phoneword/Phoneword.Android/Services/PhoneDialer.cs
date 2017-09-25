
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using Android.Telephony;
using Phoneword.Services;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(Phoneword.Droid.Services.PhoneDialer))]
namespace Phoneword.Droid.Services
{
	public class PhoneDialer : IPhoneDialer
	{
		public async Task<bool> DialNumberAsync(string number)
		{

			var context = Forms.Context;
			if (context != null)
			{
				var intent = new Intent(Intent.ActionCall);
				intent.SetData(Uri.Parse("tel:" + number));

				if (IsIntentAvailable(context, intent))
				{
					context.StartActivity(intent);
					return await Task.FromResult(true);
				}
			}

			return await Task.FromResult(false);
		}

		/// <summary>
		/// Checks if an intent can be handled.
		/// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
		{
			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
		}
	}
}