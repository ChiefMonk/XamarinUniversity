using Xamarin.Forms;
using System.Collections.Generic;
using GreatQuotes.Data;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{	
    public partial class QuoteListPage : ContentPage
	{	
        public QuoteListPage ()
		{
            BindingContext = App.MainViewModel;
			InitializeComponent ();
		}

        void OnQuoteSelected(object sender, ItemTappedEventArgs e)
        {
            //GreatQuote quote = (GreatQuote)e.Item;
            //Navigation.PushAsync(new QuoteDetailPage(new QuoteViewModel(quote)), true);

         //   QuoteViewModel quote = (QuoteViewModel)e.Item;
           // App.MainViewModel.SelectedQuote = (QuoteViewModel) e.Item;
            Navigation.PushAsync(new QuoteDetailPage(), true);

        }
	}
}

