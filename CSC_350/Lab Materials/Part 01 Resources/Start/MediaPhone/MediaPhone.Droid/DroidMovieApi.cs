using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MediaPhone
{
    public class DroidMovieApi
    {
        const string SearchUrl = "https://itunes.apple.com/search?term={0}&country=us&media=movie&limit=200&explicit=No";


        public static async Task<IEnumerable<SearchItem>> SearchAsync(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            string query = String.Format(SearchUrl, WebUtility.HtmlEncode(text));

            // Do query
            WebClient wc = new WebClient();
            string resultText = await wc.DownloadStringTaskAsync(query);

            // Parse results
            var results = JsonConvert.DeserializeObject<SearchResult>(resultText);
            return results.results;
        }      
    }
}
