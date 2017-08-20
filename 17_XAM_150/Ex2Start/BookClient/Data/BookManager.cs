using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public class BookManager
    {
        private const string Url = "http://xam150.azurewebsites.net/api/books";
        private string _authorizationKey;       

        public BookManager()
        {

        }

        private async Task<HttpClient> GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (string.IsNullOrWhiteSpace(_authorizationKey))
            {
                var response = await client.GetStringAsync($"{Url}/login");
                _authorizationKey = JsonConvert.DeserializeObject<string>(response);
            }

            client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);

            return client;
        }
       

        public async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                var client = await GetHttpClient();
                var response =  await client.GetStringAsync(Url);

                var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(response);
                return books;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Book> Add(string title, string author, string genre)
        {
            try
            {

                  

                var book = new Book
                {
                    ISBN =  string.Empty,
                    Title = title,
                    Authors = new List<string>() {author, author, author},
                    Genre = genre,
                    PublishDate = DateTime.Now 
                };

                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");               

                var client = await GetHttpClient();
                var response = await client.PostAsync(Url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {                  
                   return JsonConvert.DeserializeObject<Book>(responseString);                   
                }

                throw new Exception(responseString);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Book book)
        {          
            try
            {               
                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var client = await GetHttpClient();
                var response = await client.PutAsync($"{Url}/{book.ISBN}", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseString);
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(string isbn)
        {
            try
            {
                var client = await GetHttpClient();
                var response = await client.DeleteAsync($"{Url}/{isbn}");
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseString);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

