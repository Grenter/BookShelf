using BookShelf.Shared.Model;
using BookShelf.UI.Services;
using Microsoft.AspNetCore.Blazor.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShelf.UI.Pages
{
    public class BookViewModel : BlazorComponent
    {
        [Inject]
        private BookService BookService { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public bool DisplayAdd;

        protected override async Task OnInitAsync()
        {
            await GetBooks();
        }

        public async Task Reset()
        {
            Books = null;
            var success = await BookService.Reset();

            if (success)
            {
                await GetBooks();
            }
        }

        public async Task GetBooks()
        {
            Books = await BookService.GetBooks();
        }

        public async Task Save(Book book)
        {
            await BookService.PostBook(book);
            DisplayAdd = !DisplayAdd;
            await GetBooks();
            StateHasChanged();
        }

        public async Task Delete(string bookId)
        {
            await BookService.DeleteBook(bookId);
            await GetBooks();
            StateHasChanged();
        }
    }
}
