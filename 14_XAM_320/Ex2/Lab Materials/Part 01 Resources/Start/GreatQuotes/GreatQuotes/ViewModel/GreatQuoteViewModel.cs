
using GreatQuotes.Assets;
using GreatQuotes.Data;

namespace GreatQuotes.ViewModel
{
    public class GreatQuoteViewModel : SimpleViewModel
    {
        private readonly GreatQuote _greatQuote;
    

        public GreatQuoteViewModel(GreatQuote greatQuote)
        {
            _greatQuote = greatQuote;
        }


        public string FirstName
        {
            get => _greatQuote.FirstName;
            set
            {
                if (_greatQuote.FirstName != value)
                    _greatQuote.FirstName = value;

                RaisePropertyChanged();
                RaisePropertyChanged(() => Author);
            }
        }

        public string LastName
        {
            get => _greatQuote.LastName;
            set
            {
                if (_greatQuote.LastName != value)
                    _greatQuote.LastName = value;

                RaisePropertyChanged();
                RaisePropertyChanged(()=>Author);
            }
        }
        public string QuoteText
        {
            get => _greatQuote.QuoteText;
            set
            {
                if (_greatQuote.QuoteText != value)
                    _greatQuote.QuoteText = value;

                RaisePropertyChanged();
            }
        }
        public Gender Gender
        {
            get => _greatQuote.Gender;
            set
            {
                if (_greatQuote.Gender != value)
                    _greatQuote.Gender = value;

                RaisePropertyChanged();
            }
        }

        public string Author => $"{LastName} {FirstName}";
    }
}
