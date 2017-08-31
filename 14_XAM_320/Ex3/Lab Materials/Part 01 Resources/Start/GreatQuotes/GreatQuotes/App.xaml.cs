using System;
using Xamarin.Forms;
using GreatQuotes.Data;
using System.Linq;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var quoteList = QuoteManager.Load().ToList();
            var quote = quoteList[new Random().Next(0, quoteList.Count - 1)];
            var quoteViewModel = new GreatQuoteViewModel(quote);

            MainPage = new NavigationPage(new QuoteDetailPage(quoteViewModel));
        }
    }
}

