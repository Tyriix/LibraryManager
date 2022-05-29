using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
    public interface IBorrowBookService
    {
        Task<Borrow> AddClient(Borrow borrow);
    }
}
