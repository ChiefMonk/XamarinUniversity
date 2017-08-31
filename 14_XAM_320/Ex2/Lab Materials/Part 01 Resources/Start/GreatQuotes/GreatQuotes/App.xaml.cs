using System;
using Xamarin.Forms;
using GreatQuotes.Data;
using System.Linq;
using GreatQuotes.Assets;
using GreatQuotes.ViewModel;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var quotes = QuoteManager.Load().ToList();
            var quote = quotes[new Random().Next(0, quotes.Count - 1)];
            MainPage = new NavigationPage(new QuoteDetailPage(new GreatQuoteViewModel(quote)));
        }
    }
}

