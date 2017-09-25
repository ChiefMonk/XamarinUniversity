using System;
using System.IO;
using System.Threading.Tasks;
using MyTunes.Core;
using MyTunes.Core.Services;

namespace MyTunes.Services
{
	public class StreamLoaderService : IStreamLoaderService
	{
		public async Task<Stream> GetStreamForFilename(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new Exception("Please provide a valid filename");

			var storage = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileName);
			return await storage.OpenStreamForReadAsync();
		}
	}
}
