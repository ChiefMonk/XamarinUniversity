using Xamarin.Forms;
using GreatQuotes.Data;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(GreatQuote quote)
        {
            BindingContext = quote;
            InitializeComponent ();
        }
    }
}

