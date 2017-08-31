using GreatQuotes.ViewModels;
using Xamarin.Forms;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; }

        static App()
        {
            MainViewModel = new MainViewModel();
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new QuoteListPage());
        }
    }
}

