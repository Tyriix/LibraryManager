using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManager.Domain.Services.BookServices
{
    /// <summary>
    /// This is a service for managing Book data.
    /// It's used to Add a Book or Return all Books.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IDataService<Book> _bookService;
        private readonly IDataService<Author> _authorService;
        private readonly IDataService<Genre> _genreService;

        public BookService(IDataService<Book> bookService, IDataService<Author> authorService, IDataService<Genre> genreService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        /// <summary>
        /// This is a asynchronous function that creates a new Book.
        /// </summary>
        public async Task<Book> AddBook(Book book, Author author, Genre genre)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate,
                AuthorId = author.Id,
                GenreId = genre.Id
            };                       

            await _bookService.Create(newBook);
            MessageBox.Show("New book added.");
            return newBook;
        }
        /// <summary>
        /// This is a function that returns all Books.
        /// </summary>
        /// <returns>
        /// Returns collection of Books in the database.
        /// </returns>
        public ICollection<Book> GetBooks()
        {
            ICollection<Book> books = _bookService.GetAll();
            return books;
        }
    }
}
