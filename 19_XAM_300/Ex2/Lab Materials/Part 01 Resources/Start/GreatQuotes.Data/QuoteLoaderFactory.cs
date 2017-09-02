using System;

namespace GreatQuotes.Data
{
	public static class QuoteLoaderFactory
	{
		public static Func<IQuoteLoader> Create { get; set; }
	}
}
