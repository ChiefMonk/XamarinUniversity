using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NetStatus
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		private void SetMainPage()
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				MainPage = new NetStatus.NetworkViewPage();
			}
			else
			{
				MainPage = new NetStatus.NoNetworkPage();
			}
		}

		protected override void OnStart()
		{
			CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		protected void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			var currentType = MainPage.GetType();

			if (CrossConnectivity.Current.IsConnected)
			{
				if(currentType != typeof(NetworkViewPage))
					MainPage = new NetworkViewPage();
			}
			else
			{
				if (currentType != typeof(NoNetworkPage))
					MainPage = new NoNetworkPage();
			}
		}
	}
}
