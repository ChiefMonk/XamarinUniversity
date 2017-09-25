
using GreatQuotes.Data;

namespace GreatQuotes.ViewModels
{
	public class GreatQuoteViewModel : Assets.SimpleViewModel
	{
		private readonly GreatQuote _quote;
		public GreatQuoteViewModel(GreatQuote quote)
		{
			_quote = quote;
		}

		public string FirstName
		{
			get => _quote.FirstName;
			set
			{
				if (_quote != null && value != _quote.FirstName)
					_quote.FirstName = value;

				RaisePropertyChanged();
				RaisePropertyChanged(() => Author);
			}
		}

		public string LastName {
			get => _quote.LastName;
			set
			{
				if (_quote != null && value != _quote.LastName)
					_quote.LastName = value;

				RaisePropertyChanged();
				RaisePropertyChanged(()=>Author);
			}
		}
		public string QuoteText {
			get => _quote.QuoteText;
			set
			{
				if (_quote != null && value != _quote.QuoteText)
					_quote.QuoteText = value;

				RaisePropertyChanged();
			}
		}
		public Gender Gender {
			get => _quote.Gender;
			set
			{
				if (_quote != null && value != _quote.Gender)
					_quote.Gender = value;

				RaisePropertyChanged();
			}
		}

		public string Author => $"{FirstName} {LastName}";
	}
}
