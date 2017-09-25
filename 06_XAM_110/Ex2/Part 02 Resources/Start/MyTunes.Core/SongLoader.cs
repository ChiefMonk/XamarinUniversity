using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MyTunes.Core.Services;
using Newtonsoft.Json;

namespace MyTunes.Core
{
	public static class SongLoader
	{
		const string Filename = "songs.json";

		public static IStreamLoaderService LoaderService { get; set; }

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(await OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

		private static async Task<Stream> OpenData()
		{
			if(LoaderService == null)
				throw  new Exception("Please provide an implementation for LoaderService on type IStreamLoaderService");

			return await LoaderService.GetStreamForFilename(Filename);
		}
	}
}

