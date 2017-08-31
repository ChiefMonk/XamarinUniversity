using System;
using System.Collections.Generic;
using System.Text;

namespace GreatQuotes.Data
{
    public interface IQuoteLoader
    {
	    IEnumerable<GreatQuote> Load();

	    void Save(IEnumerable<GreatQuote> quotes);
    }
}
