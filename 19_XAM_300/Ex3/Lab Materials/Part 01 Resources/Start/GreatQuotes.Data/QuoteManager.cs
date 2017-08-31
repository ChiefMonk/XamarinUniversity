using System;
using System.Collections.ObjectModel;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {      
        private readonly IQuoteLoader _loader;
        private readonly ITextToSpeech _textToSpeech;

        public QuoteManager(IQuoteLoader loader, ITextToSpeech textToSpeech)
        {
            if(Instance != null)
                throw new Exception("Can only create a single QuoteManager");

            Instance = this;
            _loader = loader;
            _textToSpeech = textToSpeech;
            Quotes = new ObservableCollection<GreatQuote>(_loader.Load());
        }

        public static QuoteManager Instance { get; private set; }

        public ObservableCollection<GreatQuote> Quotes { get; set; }

        public void Save()
        {
            _loader.Save(Quotes);
        }

        public void SayQuote(GreatQuote quote)
        {
           // var textToSpeech = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            if(_textToSpeech == null)
                throw new ArgumentNullException(nameof(quote));

            string message = quote.QuoteText;

            if (!string.IsNullOrWhiteSpace(quote.Author))
                message = $"{message} by {quote.Author}";

            _textToSpeech.Speak(message);
        }
    }
}
