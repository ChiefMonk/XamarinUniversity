using System;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using MyTunes.Core.Services;

namespace MyTunes.Services
{
	public class StreamLoaderService : StreamLoaderServiceBase, IStreamLoaderService
	{
		
		public async Task<Stream> GetStreamForFilename(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new Exception("Please provide a valid filename");

			return await Task.Run(()=>System.IO.File.OpenRead(fileName));
		}
	}
}
