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

	        var list = QuoteManager.Load().ToList();
			var quote = list[new Random().Next(list.Count)];
			var viewModel = new GreatQuoteViewModel(quote);
            MainPage = new NavigationPage(new QuoteDetailPage(viewModel));
        }
    }
}

