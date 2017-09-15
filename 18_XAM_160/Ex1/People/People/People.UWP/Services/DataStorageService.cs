using People.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(People.UWP.Services.DataStorageService))]
namespace People.UWP.Services
{
	public class DataStorageService :IDataStorageService
	{
		public string GetLocalFilePath(string fileName)
		{
			return System.IO.Path.Combine(GetAppHomePath(), fileName);
		}

		public string GetAppHomePath()
		{
			return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
		}

		public string GetDatabaseHomePath()
		{
			return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
		}
	}
}
