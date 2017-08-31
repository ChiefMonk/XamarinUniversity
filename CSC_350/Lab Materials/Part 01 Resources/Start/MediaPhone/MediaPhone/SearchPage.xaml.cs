using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Net;

namespace MediaPhone
{
    public partial class SearchPage : ContentPage
    {
        IList<SearchItem> Data = new ObservableCollection<SearchItem>();

        public SearchPage()
        {
            InitializeComponent();
            searchResults.ItemsSource = Data;
        }

        protected async void OnSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBar.Text))
                return;

            Data.Clear();
            searchProgress.IsRunning = true;

            try
            {
                var results = await MovieApi.SearchAsync(searchBar.Text);
                foreach (var item in results)
                    Data.Add(item);
            }
            catch (WebException ex)
            {
                await DisplayAlert("Error", ex.Message + "\r\nAre you connected to the Internet?", "OK");
            }
            finally
            {
                searchProgress.IsRunning = false;
            }
        }

        void OnSearch2 (object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBar.Text))
                return;

            Data.Clear();
            searchProgress.IsRunning = true;

            try
            {
                var results = MovieApi.Search(searchBar.Text);
                foreach (var item in results)
                    Data.Add(item);
            }
            catch (WebException ex)
            {
                DisplayAlert("Error", ex.Message + "\r\nAre you connected to the Internet?", "OK");
            }
            finally
            {
                searchProgress.IsRunning = false;
            }
        }
    }
}