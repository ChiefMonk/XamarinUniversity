using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Phoneword.Services;

[assembly:Xamarin.Forms.Dependency(typeof(Phoneword.UWP.Services.PhoneDialer))]

namespace Phoneword.UWP.Services
{
	public class PhoneDialer : IPhoneDialer
	{
		public async Task<bool> DialNumberAsync(string number)
		{
			if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1, 0))
			{
				Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");

				return await Task.FromResult(true);
			}
			return await Task.FromResult(false);
		}
	}
}