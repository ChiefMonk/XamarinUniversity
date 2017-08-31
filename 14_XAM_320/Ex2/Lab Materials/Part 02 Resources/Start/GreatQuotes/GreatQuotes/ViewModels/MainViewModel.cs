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
        private IList<GreatQuote> _quoteList;

        public MainViewModel()
        {
            // _quotes = quotes;
        }

        public ObservableCollection<QuoteViewModel> Quotes
        {
            get
            {
                if (_quoteList == null || _quoteList.Count == 0)
                    _quoteList = new List<GreatQuote>(QuoteManager.Load());

                SelectedQuote = new QuoteViewModel(_quoteList[0]);

                return new ObservableCollection<QuoteViewModel>(_quoteList.Select(q => new QuoteViewModel(q)));
            }
        }

        public QuoteViewModel SelectedQuote
        {
            get => _selectedQuote;

            set
            {
                _selectedQuote = value;
                RaisePropertyChanged();
            }
        }
    }
}
