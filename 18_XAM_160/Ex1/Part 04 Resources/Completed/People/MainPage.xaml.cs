using People.Models;
using System;
using System.Collections.ObjectModel;

namespace People
{
    public partial class MainPage
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

            ObservableCollection<Person> people = 
                new ObservableCollection<Person>(
                    await App.PersonRepo.GetAllPeopleAsync());
            peopleList.ItemsSource = people;
        }
    }
}
