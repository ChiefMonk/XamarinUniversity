using Phoneword.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Phoneword.UWP.Services.ToastMessage))]
namespace Phoneword.UWP.Services
{
	public class ToastMessage : IToastMessage
	{
		public void LongAlert(string message)
		{
			
		}

		public void ShortAlert(string message)
		{
			
		}
	}
}
