using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
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
            await _authorService.Update(author.Id, author);
            await _genreService.Update(genre.Id, genre);
            return newBook;
        }
    }
}
