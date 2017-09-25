using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			var dataSource = await SongLoader.Load();
			//var source = dataSource.Select(c => c.Artist + " - " + c.Album).ToList();

			TableView.Source = new ViewControllerSource<Song>(TableView)
			{
				DataSource = dataSource.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = c => c.Artist + " - " + c.Album,
			};
			

			//TableView.Source = new ViewControllerSource<string>(TableView) {
			//	DataSource = await SongLoader.Load(), // DataSource = new string[] { "One", "Two", "Three" },
			//};


		}
	}

}

