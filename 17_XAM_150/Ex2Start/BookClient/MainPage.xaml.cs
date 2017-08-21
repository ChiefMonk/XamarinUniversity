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
            var bookCollection = await manager.GetAll();

            foreach (Book book in bookCollection)
            {
                if (books.All(b => b.ISBN != book.ISBN))
                    books.Add(book);
            }

            IsBusy = false;
        }

        async void OnAddNewBook(object sender, EventArgs e)
        {
            IsBusy = true;

            await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books));

            IsBusy = false;
        }

        async void OnEditBook(object sender, ItemTappedEventArgs e)
        {
            IsBusy = true;

            await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books, (Book)e.Item));

            IsBusy = false;
        }

        async void OnDeleteBook(object sender, EventArgs e)
        {
            IsBusy = true;

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

            IsBusy = false;
        }
    }
}
