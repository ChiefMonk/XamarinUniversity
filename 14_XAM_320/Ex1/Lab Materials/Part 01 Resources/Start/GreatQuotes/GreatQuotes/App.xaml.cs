using Xamarin.Forms;
using GreatQuotes.Data;
using System.Linq;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var quote = QuoteManager.Load().First();
            MainPage = new NavigationPage(new QuoteDetailPage(quote));
        }
    }
}

