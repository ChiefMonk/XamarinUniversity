using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTunes
{
	public static class SongLoader
	{
		const string Filename = "songs.json";

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader( await OpenData()))
			{
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

		private async static Task<Stream> OpenData()
		{			
#if __IOS__
			return System.IO.File.OpenRead(Filename);

#elif __ANDROID__
			return Android.App.Application.Context.Assets.Open(Filename);


#elif WINDOWS_PHONE || WINDOWS_UWP

		var storage = await	Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(Filename);
			return await storage.OpenStreamForReadAsync();
#endif

			return null;
		}
	}
}

