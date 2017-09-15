using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using GroceryList.Data;

namespace GroceryList
{
	[Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{		
		protected override void OnCreate(Bundle bundle)
		{
			ItemRepository.Instance.AddItem(new ModelItem("Milk",     2));
			ItemRepository.Instance.AddItem(new ModelItem("Crackers", 1));
			ItemRepository.Instance.AddItem(new ModelItem("Apples",   5));

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.itemsButton  ).Click += OnItemsClick;
			FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
			FindViewById<Button>(Resource.Id.aboutButton  ).Click += OnAboutClick;
		}

		protected void OnItemsClick(object sender, EventArgs e)
		{
			// TODO
			var itemsIntent = new Intent(this, typeof(ItemsActivity)); 
			StartActivity(itemsIntent);
		}

		protected void OnAddItemClick(object sender, EventArgs e)
		{
			// TODO
			var addItemIntent = new Intent(this, typeof(AddItemActivity));

			StartActivityForResult(addItemIntent, 100);			
		}

		protected void OnAboutClick(object sender, EventArgs e)
		{
			// TODO
			StartActivity(typeof(AboutActivity));
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (requestCode == 100)
			{
				Toast  toast = null;
				if (resultCode == Result.Ok)
				{
					var item = new ModelItem(data.GetStringExtra("ItemName"), data.GetLongExtra("ItemCount", -1));
					ItemRepository.Instance.AddItem(item);
					toast = Toast.MakeText(this, $"Item '{item}' has been added successfully", ToastLength.Long);
				}
				else if (resultCode == Result.Canceled)
				{
					toast = Toast.MakeText(this, $"Addition of an item has been cancelled", ToastLength.Long);
				}

				toast?.Show();
			}
		}
	}
}