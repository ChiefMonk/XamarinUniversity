using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          
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
            // Handle when your app starts

         //   base.OnStart();
         //   CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;

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
            var currentPage = MainPage.GetType();

            if (e.IsConnected)
            {
                if (currentPage != typeof(NetworkViewPage))
                    MainPage = new NoNetworkPage();
            }
            else
            {
                if (currentPage != typeof(NoNetworkPage))                
                    MainPage = new NetworkViewPage();                
            }          
        }
    }
}
