using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunFlacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFlagsPage : ContentPage
    {
        bool isEditing;
        ToolbarItem cancelEditButton;
        public AllFlagsPage()
        {
           
            BindingContext = DependencyService.Get<FunFlactsViewModel>();

            InitializeComponent();
            cancelEditButton = (ToolbarItem)Resources[nameof(cancelEditButton)];
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var tbItem = sender as ToolbarItem;
            isEditing = (tbItem == editButton);

            ToolbarItems.Remove(tbItem);
            ToolbarItems.Add(isEditing ? cancelEditButton : editButton);
        }
        private async void OnFlagItemTapped(object sender, ItemTappedEventArgs e)
        {
            //  var tappedFlag = (Flag) e.Item;
            //            DependencyService.Get<FunFlactsViewModel>().CurrentFlag = tappedFlag;

            if (!isEditing)
            {
                await this.Navigation.PushAsync(new FlagDetailsPage());
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (isEditing)
            {
                var flag = (Flag)e.SelectedItem;
                if (flag != null && await this.DisplayAlert("Confirm",
                        $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
                {
                    DependencyService.Get<FunFlactsViewModel>()
                        .Flags.Remove(flag);
                }
                // Reset the edit button
                OnEdit(cancelEditButton, EventArgs.Empty);
            }
        }

        private void OnRefreshing(object sender, EventArgs e)
        {
            flagsListView.IsRefreshing = true;

            flagsListView.IsRefreshing = false;
        }
    }
}