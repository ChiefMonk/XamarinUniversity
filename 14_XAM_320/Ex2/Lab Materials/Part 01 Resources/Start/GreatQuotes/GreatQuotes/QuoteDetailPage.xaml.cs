using Xamarin.Forms;
using GreatQuotes.ViewModel;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(GreatQuoteViewModel greatQuoteViewModel)
        {
            BindingContext = greatQuoteViewModel;
            InitializeComponent ();
        }
    }
}

