using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using Newtonsoft.Json;

namespace MediaPhone
{
    public class MovieApi
    {
        const string SearchUrl = "https://itunes.apple.com/search?term={0}&country=us&media=movie&limit=200&explicit=No";

        public static IEnumerable<SearchItem> Search(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            string query = string.Format(SearchUrl, WebUtility.HtmlEncode(text));

            // Do query
            WebClient wc = new WebClient();
            string resultText = wc.DownloadString(query);

            // Parse results
            var results = JsonConvert.DeserializeObject<SearchResult>(resultText);
            return results.results;
        }

        public event Action<IEnumerable<SearchItem>, Exception> SearchComplete;
        public void SearchAsync(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            string query = string.Format(SearchUrl, WebUtility.HtmlEncode(text));

            // Do query
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (sender, e) => 
            {
                if (e.Error == null)
                {
                    string resultText = e.Result;

                    // Parse results
                    var results = JsonConvert.DeserializeObject<SearchResult>(resultText);
                    SearchComplete?.Invoke(results.results, null);
                }
                else
                {
                    SearchComplete?.Invoke(null, e.Error);
                }
            };

            wc.DownloadStringAsync(new Uri(query));
        }
    }
}