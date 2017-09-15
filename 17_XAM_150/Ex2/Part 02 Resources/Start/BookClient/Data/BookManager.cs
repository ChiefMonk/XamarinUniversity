using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public class BookManager
    {
	    private const string ServerUrl = "http://xam150.azurewebsites.net/api/books/";
	    private string _authorizationKey;

        public async Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
	        var client = await GetClient();
	        var response = await client.GetStringAsync(ServerUrl);
	        return JsonConvert.DeserializeObject<IEnumerable<Book>>(response);
        }

	    public async Task<Book> Add(string title, string author, string genre)
	    {
		    var client = await GetClient();
		    var book = new Book
		    {
			    ISBN = null,
			    Title = title,
			    Authors = new List<string>(),
			    PublishDate = DateTime.Now,
			    Genre = genre,
		    };
		    book.Authors.Add(author);

		    var jsonContent = JsonConvert.SerializeObject(book);
		    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

		    var response = await client.PostAsync(ServerUrl, content);

		    if (response.IsSuccessStatusCode)
		    {
			    var jsonResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Book>(jsonResponse);
		    }

		    return null;
	    }

	    public async Task Update(Book book)
        {
			var client = await GetClient();	       
	        var jsonContent = JsonConvert.SerializeObject(book);
	        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

	        var response = await client.PutAsync($"{ServerUrl}/{book.ISBN}", content);

	        if (response.IsSuccessStatusCode)
	        {
		        var jsonResponse = await response.Content.ReadAsStringAsync();		       
	        }
		}

		public async Task Delete(string isbn)
        {
			var client = await GetClient();	       
	        var response = await client.DeleteAsync($"{ServerUrl}/{isbn}");

	        if (response.IsSuccessStatusCode)
	        {
		        var jsonResponse = await response.Content.ReadAsStringAsync();
	        }
		}

		#region Private Methods

	    private HttpClient _httpClient = null;
		private async Task<HttpClient> GetClient()
	    {
		    if (_httpClient == null)
		    {
				_httpClient = new HttpClient();
			    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			}

		    if (string.IsNullOrWhiteSpace(_authorizationKey))
		    {
			    var response = await _httpClient.GetStringAsync($"{ServerUrl}/login");
			    _authorizationKey = JsonConvert.DeserializeObject<string>(response);
			    _httpClient.DefaultRequestHeaders.Add("Authorization", _authorizationKey);

		    }

		    return _httpClient;

	    }
		#endregion
	}
}

