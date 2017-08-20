using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public interface IBookHttpClient: IDisposable
    {
        Task<string> LoginAsync();
        Task<List<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(string isbn);
        Task<bool> UpdateBookAsync(Book book);

    } 
    public class BookHttpClient : HttpClient, IBookHttpClient
    {
        private const string ServerUrl = " http://xam150.azurewebsites.net/api/books";
        private readonly string _authToken;

        #region Constructors

        public BookHttpClient(string authToken)
        {
            _authToken = authToken;
        }
        #endregion

        #region Methods

        public async Task<string> LoginAsync()
        {           
            var request = CreateRequestMessage("login", HttpMethod.Get, null);
            var response = await SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<string>(responseString);


            throw new Exception(responseString);
        }

        public async Task<List<Book>> GetBooksAsync()
        {           
            var request = CreateRequestMessage(null, HttpMethod.Get, null);          
            var response = await SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Book>>(responseString);              
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (string.IsNullOrWhiteSpace(responseString))
                    responseString = "This request was Unauthorized";               
            }

            throw new Exception(responseString);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            book.ISBN = string.Empty;

            var request = CreateRequestMessage(null, HttpMethod.Post, book);
            var response = await SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Book>(responseString);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (string.IsNullOrWhiteSpace(responseString))
                    responseString = "This request was Unauthorized";
            }

            throw new Exception(responseString);
        }

        public async Task<bool> DeleteBookAsync(string isbn)
        {           
            var request = CreateRequestMessage(isbn, HttpMethod.Delete, null);
            var response = await SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (string.IsNullOrWhiteSpace(responseString))
                    responseString = "This request was Unauthorized";
            }

            throw new Exception(responseString);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {           
            var request = CreateRequestMessage(book.ISBN, HttpMethod.Put, book);
            var response = await SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (string.IsNullOrWhiteSpace(responseString))
                    responseString = "This request was Unauthorized";
            }

            throw new Exception(responseString);
        }

        private HttpRequestMessage CreateRequestMessage(string url, HttpMethod httpMethod, object content)
        {
            var finalUrl = ServerUrl;

            if (!string.IsNullOrWhiteSpace(url))
                finalUrl = $"{ServerUrl}/{url}";

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(finalUrl),
                Method = httpMethod
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(_authToken))
            {
                request.Headers.Add("Authorization", _authToken);
            }          

            if (content != null)
            {
                var jsonContent = JsonConvert.SerializeObject(content);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");              

                request.Content = stringContent;
            }

            return request;

        }

        #endregion
    }
}
