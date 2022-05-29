using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
    public interface IAddBookService
    {
        Task<Book> AddClient(Book client);
    }
}
