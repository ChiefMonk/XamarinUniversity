using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using MyTunes.Core;
using MyTunes.Core.Services;

namespace MyTunes.Services
{
	public class StreamLoaderService : IStreamLoaderService
	{
		private readonly Context _context;
		public StreamLoaderService(Context context)
		{
			_context = context;
		}

		public async Task<Stream> GetStreamForFilename(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new Exception("Please provide a valid filename");

			return await Task.Run(() => _context.Assets.Open(fileName));
		}
	}
}
