using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatQuotes.Data;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using XamarinUniversity.Infrastructure;
using XamarinUniversity.Interfaces;
using System.Windows.Input;
using System;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        public IList<QuoteViewModel> Quotes { get; private set; }

        QuoteViewModel selectedQuote;
        public QuoteViewModel SelectedQuote {
            get {
                return selectedQuote;
            }
            set {
                SetPropertyValue(ref selectedQuote, value);
            }
        }

        public ICommand AddQuote { get; private set; }
        public ICommand DeleteQuote { get; private set; }
        public ICommand EditQuote { get; private set; }

        public ICommand ShowQuoteDetail { get; private set; }

        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(QuoteManager.Load()
                            .Select(q => new QuoteViewModel(q)));

            SelectedQuote = Quotes.FirstOrDefault();

            AddQuote = new Command(async () => await OnAddQuote());
            DeleteQuote = new Command<QuoteViewModel>(async qvm => await OnDeleteQuote(qvm));
            EditQuote = new Command<QuoteViewModel>(async qvm => await OnEditQuote(qvm));
            ShowQuoteDetail = new Command<QuoteViewModel>(async qvm => await OnShowQuoteDetails(qvm));
        }

        private async Task OnShowQuoteDetails(QuoteViewModel qvm)
        {
            SelectedQuote = qvm;
            await DependencyService.Get<INavigationService>()
                .NavigateAsync(AppPages.Detail);
        }

        private async Task OnAddQuote()
        {
            var newQuote = new QuoteViewModel();
            Quotes.Add(newQuote);
            SelectedQuote = newQuote;

            if (!DependencyService.Get<INavigationService>().CanGoBack)
            {
                await DependencyService.Get<INavigationService>()
                                   .NavigateAsync(AppPages.Edit, newQuote);
            }
        }

        private async Task OnEditQuote(QuoteViewModel quote)
        {
            SelectedQuote = quote;
            await DependencyService.Get<INavigationService>()
                .NavigateAsync(AppPages.Edit, quote);
        }

        private async Task OnDeleteQuote(QuoteViewModel quote)
        {
            bool result = await DependencyService.Get<IMessageVisualizerService>()
                .ShowMessage("Are you sure?", 
                    "Are you sure you want to delete this quote from " + quote.Author + "?",
                    "Yes", "No");

            if (result == true) {
                int pos = Quotes.IndexOf(quote);
                Quotes.Remove(quote);
                if (SelectedQuote == quote) {
                    if (pos > Quotes.Count - 1)
                        pos = Quotes.Count - 1;
                    SelectedQuote = Quotes[pos];
                }
            }
        }
    }
}

