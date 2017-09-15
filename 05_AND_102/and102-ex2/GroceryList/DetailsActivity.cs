using Android.App;
using Android.OS;
using Android.Widget;
using GroceryList.Data;

namespace GroceryList
{
	[Activity(Label = "Details")]			
	public class DetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Details);

		//	int position = 0;

			// TODO
			int position = Intent.GetIntExtra("ItemPosition", -1);

			var item = ItemRepository.Instance.ItemCollection[position];

			FindViewById<TextView>(Resource.Id.nameTextView ).Text = "Name: "  + item.Name;
			FindViewById<TextView>(Resource.Id.countTextView).Text = "Count: " + item.Count.ToString();
		}
	}
}