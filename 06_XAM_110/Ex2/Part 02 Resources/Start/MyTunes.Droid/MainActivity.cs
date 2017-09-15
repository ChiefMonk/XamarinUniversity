using System.Linq;
using Android.App;
using Android.OS;
using MyTunes.Core;
using MyTunes.Services;

namespace MyTunes
{
	[Activity(Label = "My Tunes", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SongLoader.LoaderService = new StreamLoaderService(this);
			var data = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song>() {
				DataSource = data.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = s => s.Artist + " - " + s.Album
			};
		}
	}
}


