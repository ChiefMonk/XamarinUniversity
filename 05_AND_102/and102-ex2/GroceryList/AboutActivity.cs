using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "About")]			
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.About);

			FindViewById<Button>(Resource.Id.learnMoreButton).Click += OnLearnMoreClick;
		}

		void OnLearnMoreClick(object sender, EventArgs e)
		{
			// TODO
			var learnIntent = new Intent(Intent.ActionView);
			learnIntent.SetAction(Intent.ActionView);
			learnIntent.SetData(Android.Net.Uri.Parse("http://www.xamarin.com"));
			
			if (learnIntent.ResolveActivity(PackageManager) != null)
			{
				StartActivity(learnIntent);
			}
		}

		void OnLearnMoreClick2(object sender, EventArgs e)
		{
			// TODO
			var learnIntent = new Intent();
			learnIntent.SetAction(Intent.ActionDial);
			learnIntent.SetData(Android.Net.Uri.Parse("tel:+27824211330"));
			//learnIntent.PutExtra(Intent.ExtraPhoneNumber, "+27824211330");

			if (learnIntent.ResolveActivity(PackageManager) != null)
			{
				StartActivity(learnIntent);
			}
		}
	}
}