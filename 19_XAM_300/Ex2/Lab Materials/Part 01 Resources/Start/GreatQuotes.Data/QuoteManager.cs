using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {
		private static readonly Lazy<QuoteManager> _instance = new Lazy<QuoteManager>(()=> new QuoteManager() );
	    private readonly IQuoteLoader _loader;

	    public static QuoteManager Instance => _instance.Value;

	    public QuoteManager()
	    {		
		    _loader = QuoteLoaderFactory.Create();
		    Quotes = new ObservableCollection<GreatQuote>(_loader.Load());
	    }

		public IList<GreatQuote> Quotes { get; set; }

	    public void Save()
	    {
			_loader.Save(Quotes);

		}

	    public void SayQuote (GreatQuote quote)
	    {
			if(quote == null)
				throw  new ArgumentNullException(nameof(quote));

		    var textToSpeech = ServiceLocator.Instance.Resolve<ITextToSpeech>();

		    if (textToSpeech != null)
		    {
			    string text = quote.QuoteText;

			    if (!string.IsNullOrWhiteSpace(quote.Author))
				    text = $"{text} by {quote.Author}";

			    textToSpeech.Speak(text);
		    }
	    }
	}
}
