using BookClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookClient
{
    public partial class MainPage : ContentPage
    {
        readonly IList<Book> books = new ObservableCollection<Book>();
        readonly BookManager manager = new BookManager();

        public MainPage()
        {
            BindingContext = books;
            InitializeComponent();
        }

        async void OnRefresh(object sender, EventArgs e)
        {
	        IsBusy = true;
	        try
	        {
		        var bookCollection = await manager.GetAll();

		        foreach (Book book in bookCollection)
		        {
			        if (books.All(b => b.ISBN != book.ISBN))
				        books.Add(book);
		        }
	        }
	        catch (Exception exception)
	        {
		       
	        }
	        finally
	        {
				IsBusy = false;
			}
            
        }

        async void OnAddNewBook(object sender, EventArgs e)
        {
	        IsBusy = true;
	        try
	        {
				await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books));
	        }
	        catch (Exception exception)
	        {

	        }
	        finally
	        {
		        IsBusy = false;
	        }
		}

        async void OnEditBook(object sender, ItemTappedEventArgs e)
        {
	        IsBusy = true;
	        try
	        {
					await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books, (Book)e.Item));
	        }
	        catch (Exception exception)
	        {

	        }
	        finally
	        {
		        IsBusy = false;
	        }
		}

        async void OnDeleteBook(object sender, EventArgs e)
        {
	        IsBusy = true;
	        try
	        {
						MenuItem item = (MenuItem)sender;
            Book book = item.CommandParameter as Book;
            if (book != null)
            {
                if (await this.DisplayAlert("Delete Book?",
                    "Are you sure you want to delete the book '"
                        + book.Title + "'?", "Yes", "Cancel") == true)
                {
                    await manager.Delete(book.ISBN);
                    books.Remove(book);
                }
            }
	        }
	        catch (Exception exception)
	        {

	        }
	        finally
	        {
		        IsBusy = false;
	        }
		}
    }
}
