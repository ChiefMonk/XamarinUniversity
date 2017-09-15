using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using GroceryList.Data;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e)
		{
			// TODO
			Toast toast;

			const string nameError = "Please enter a valid name for this item";
			const string countError = "Please enter a valid positive count input for this item";

			var name  = FindViewById<EditText>(Resource.Id.nameInput).Text;

			if (string.IsNullOrWhiteSpace(name))
			{
				toast = Toast.MakeText(this, nameError, ToastLength.Short);
				toast.Show();
				return;
			}

			long count;
			long.TryParse(FindViewById<EditText>(Resource.Id.countInput).Text, out count);

			if (count <= 0)
			{
				toast = Toast.MakeText(this, countError, ToastLength.Short);
				toast.Show();
				return;
			}
					
			var saveIntent = new Intent();
			saveIntent.PutExtra("ItemName", name);
			saveIntent.PutExtra("ItemCount", count);

			SetResult(Result.Ok, saveIntent);

			Finish();
		}

		void OnCancelClick(object sender, EventArgs e)
		{
			var prompt = new AlertDialog.Builder(this);
			prompt.SetTitle("Confirm Cancellation");
			prompt.SetMessage("Are you sure you want to cancel this Item");
			prompt.SetPositiveButton("Yes", (bs, be) =>
			{				
				Finish();
			});
			prompt.SetNegativeButton("No", (ns, ne) =>
			{

			});

			RunOnUiThread(() =>
			{
				prompt.Show();
			});
		}
	}
}