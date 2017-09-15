using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyTunes.NetStandard
{
	public static class SongLoader
	{
        const string Filename = "songs.json";

        public static async Task<IEnumerable<Song>> Load()
        {
			using (var reader = new StreamReader(OpenData()))
            {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }

        public static IStreamLoader Loader { get; set; }

		private static Stream OpenData()
        {
            if (Loader == null)
                throw new Exception("Must set platform Loader before calling Load.");

            return Loader.GetStreamForFilename(Filename);
        }

		const string ResourceName = "MyTunes.NetStandard.songs.json";
		public static async Task<IEnumerable<Song>> ImprovedLoad()
		{
		    var assembly = typeof(SongLoader).GetTypeInfo().Assembly;
		    using (var stream = assembly.GetManifestResourceStream(ResourceName))
		    using (var reader = new StreamReader(stream))
		    {
		        var songs =  JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			  
				foreach (var song in songs)
				{
					song.Name = song.Name.RuinSongName();
				}

			    return songs;

		    }
		}
	}
}

