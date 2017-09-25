using System;
using System.IO;
using People.iOS.Services;
using People.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataStorageService))]
namespace People.iOS.Services
{
	public class DataStorageService :IDataStorageService
	{
		public string GetLocalFilePath(string fileName)
		{
			var libraryFoler = System.IO.Path.Combine(GetAppHomePath(), "..", "Library");

			if (!Directory.Exists(libraryFoler))
			{
				Directory.CreateDirectory(libraryFoler);
			}
			return System.IO.Path.Combine(libraryFoler, fileName);
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
