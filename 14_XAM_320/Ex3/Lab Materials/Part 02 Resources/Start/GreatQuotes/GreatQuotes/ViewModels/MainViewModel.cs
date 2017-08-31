using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GreatQuotes.Data;
using GreatQuotes.Infrastructure;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        private QuoteViewModel _selectedQuote;

        public MainViewModel()
        {
            var quotes = QuoteManager.Load();
            Quotes = new ObservableCollection<QuoteViewModel>(quotes.Select(q => new QuoteViewModel(q)));
        }

        public ObservableCollection<QuoteViewModel> Quotes { get; private set; }

        public QuoteViewModel SelectedQuote
        {
            get => _selectedQuote;
            set => SetPropertyValue(ref _selectedQuote, value);
        }
    }
}
