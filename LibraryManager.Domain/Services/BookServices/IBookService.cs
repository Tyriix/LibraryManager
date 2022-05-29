using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
    public interface IBookService
    {
        ICollection<Book> GetBooks();
        Task<Book> AddBook(Book book, Author author, Genre genre);
    }
}
