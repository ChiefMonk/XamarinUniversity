using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using GroceryList.Data;

namespace GroceryList
{
	[Activity(Label = "Items")]			
	public class ItemsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Items);

			var lv = FindViewById<ListView>(Resource.Id.listView);
			lv.Adapter = new ArrayAdapter<ModelItem>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, ItemRepository.Instance.ItemCollection);	
			lv.ItemClick += OnItemClick;
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var position = e.Position; // e.Position is the position in the list of the item the user touched

			// TODO
			var detailsIntent  = new Intent(this, typeof(DetailsActivity));
			detailsIntent.PutExtra("ItemPosition", position);

			StartActivity(detailsIntent);			
		}
	}
}