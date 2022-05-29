using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BorrowServices
{
    public interface IBorrowService
    {
        ICollection<Borrow> GetBorrows();
        Task<Borrow> BorrowBook(Borrow borrow, Book book, Client client);
    }
}
