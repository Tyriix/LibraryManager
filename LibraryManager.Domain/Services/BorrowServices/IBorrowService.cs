using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BorrowServices
{
    /// <summary>
    /// This is an interface for managing Borrow data.
    /// </summary>
    public interface IBorrowService
    {
        ICollection<Borrow> GetBorrows();
        Task<Borrow> BorrowBook(Borrow borrow, Book book, Client client);

    }
}
