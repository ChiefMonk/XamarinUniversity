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

            if (CrossConnectivity.Current == null)
                return;

            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
            SetConnectivityStatus();
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs connectivityChangedEventArgs)
        {
           SetConnectivityStatus();
        }

        private void SetConnectivityStatus()
        {

            LblConnectionDetails.Text = "No Network Connection Available";
            LblConnectionDetails.TextColor = Color.DarkRed;

            if (CrossConnectivity.Current == null)
                return;

            if (CrossConnectivity.Current.IsConnected && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                LblConnectionDetails.Text = $"Connection Type is : {connectionType}";
                LblConnectionDetails.TextColor = Color.DarkGreen;
            }
        }

        protected override void OnDisappearing()
        {
            if (CrossConnectivity.Current == null)
                return;

            CrossConnectivity.Current.ConnectivityChanged -= OnConnectivityChanged;
        }
    }
}