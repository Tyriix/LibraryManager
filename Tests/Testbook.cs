using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.EntityFramework.Services;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class Testbook
    {
        public async Task<string> Test()
        {
            IDataService<Book> bookDataService = new GenericDataService<Book>(new EntityFramework.LibraryManagerDbContextFactory());
            IDataService<Author> authorDataService = new GenericDataService<Author>(new EntityFramework.LibraryManagerDbContextFactory());
            IDataService<Genre> genreDataService = new GenericDataService<Genre>(new EntityFramework.LibraryManagerDbContextFactory());

            IBookService bookService = new BookService(bookDataService, authorDataService, genreDataService);

            Book newBook = new Book()
            {
                Title = "TestBook1",
                PageCount = 100,
                PublishDate = DateTime.Now,
                Author = authorDataService.Get(1).Result,
                Genre = genreDataService.Get(1).Result
            };
            var result = await bookService.AddBook(newBook, authorDataService.Get(1).Result, genreDataService.Get(1).Result);
            return result.ToString();
        }
    }
}