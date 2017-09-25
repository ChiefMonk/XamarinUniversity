using System.IO;
using System.Threading.Tasks;

namespace MyTunes.Core.Services
{
	public interface IStreamLoaderService
	{
		Task<Stream> GetStreamForFilename(string fileName);
	}
}
