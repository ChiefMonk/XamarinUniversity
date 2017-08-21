using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			//ListAdapter = new ListAdapter<string>() {DataSource = new[] { "One", "Two", "Three" }};

		    var songListResponse = await SongLoader.Load();
		   
		    ListAdapter = new ListAdapter<Song>()
		    {
		        DataSource = songListResponse.ToList(),
		        TextProc = s=>s.Name,
                DetailTextProc = s=> $"{s.Artist} - {s.Album}",
		    };


		}
	}
}


