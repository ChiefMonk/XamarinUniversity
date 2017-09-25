using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using People.Entities;

namespace People
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
                        
           await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }
        
        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            var people = new ObservableCollection<EntityPerson>( await App.PersonRepo.GetAllPeopleAsync());
            peopleList.ItemsSource = people;
        }
    }
}
