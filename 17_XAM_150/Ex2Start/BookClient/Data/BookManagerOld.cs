using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
    public class BookManagerOld
    {
        private string _authorizationKey;
       
        public BookManagerOld()
        {

        }

    

        public async Task Login()
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(_authorizationKey))
                    return;

                using (var client = new BookHttpClient(_authorizationKey))
                {
                    _authorizationKey =  await client.LoginAsync();
                }              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                await Login();
                using (var client = new BookHttpClient(_authorizationKey))
                {
                   return await client.GetBooksAsync();
                }

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

                await Login();
                using (var client = new BookHttpClient(_authorizationKey))
                {
                    var book = new Book
                    {
                        ISBN = string.Empty,
                        Title = title,
                        Authors = new List<string>() { author, author, author },
                        Genre = genre,
                        PublishDate = DateTime.Now
                    };


                   return await client.AddBookAsync(book);
                }

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
                await Login();
                using (var client = new BookHttpClient(_authorizationKey))
                {
                    await client.UpdateBookAsync(book);
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
                await Login();
                using (var client = new BookHttpClient(_authorizationKey))
                {
                    await client.DeleteBookAsync(isbn);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

