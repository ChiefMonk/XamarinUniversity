using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetStatus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NetworkViewPage : ContentPage
	{
		public NetworkViewPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (CrossConnectivity.Current == null || CrossConnectivity.Current.ConnectionTypes == null)
				return;
		
			var connectionTypes = CrossConnectivity.Current.ConnectionTypes.ToList();
			LblConnectionDetails.Text = $"Connection Type : {connectionTypes.FirstOrDefault()}";

			CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
		}

		protected void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (CrossConnectivity.Current == null || CrossConnectivity.Current.ConnectionTypes == null)
				return;

			LblConnectionDetails.Text = $"Connection Type : {CrossConnectivity.Current.ConnectionTypes.FirstOrDefault()}";
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (CrossConnectivity.Current == null)
				return;

			CrossConnectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
		}
	}

}