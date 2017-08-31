using Xamarin.Forms;
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
            var quoteViewModel = (QuoteViewModel)e.Item;
            Navigation.PushAsync(new QuoteDetailPage(), true);
        }
	}
}

