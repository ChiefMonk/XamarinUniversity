using Xamarin.Forms;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new QuoteListPage());
        }
    }
}

