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

			var dataSource = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song>()
			{
				DataSource = dataSource.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = c => c.Artist + " - " + c.Album,
			};


			//ListAdapter = new ListAdapter<string>() {
			//	DataSource = new[] { "One", "Two", "Three" }
			//};
		}
	}
}


