using System;
using System.Net.Http;

namespace MyTunes.NetStandard
{
	public static class SongExtensions
	{
		//public static HttpClient Client = new HttpClient();

		public static string RuinSongName(this string songName)
		{

			return songName.Replace("Crocodile", "Alligator");
		}
	}
}
