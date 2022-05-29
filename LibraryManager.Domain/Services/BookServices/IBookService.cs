using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
    /// <summary>
    /// This is an interface for managing Book data.
    /// </summary>
    public interface IBookService
    {
        ICollection<Book> GetBooks();
        Task<Book> AddBook(Book book, Author author, Genre genre);
    }
}
