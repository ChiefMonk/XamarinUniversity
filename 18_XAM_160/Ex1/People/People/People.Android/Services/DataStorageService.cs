using System;
using People.Droid.Services;
using People.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataStorageService))]
namespace People.Droid.Services
{
	public class DataStorageService :IDataStorageService
	{
		public string GetLocalFilePath(string fileName)
		{
			return System.IO.Path.Combine(GetAppHomePath(), fileName);
		}

		public string GetAppHomePath()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}

		public string GetDatabaseHomePath()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}
	}
}
