using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BorrowServices
{
    /// <summary>
    /// This is a service for managing Borrow data.
    /// It's used to Add a Borrow or Return all Borrows.
    /// </summary>
    public class BorrowService : IBorrowService
    {
        private readonly IDataService<Borrow> _borrowService;
        private readonly IDataService<Client> _clientService;
        private readonly IDataService<Book> _bookService;

        public BorrowService(IDataService<Borrow> borrowService, IDataService<Client> clientService, IDataService<Book> bookService)
        {
            _borrowService = borrowService;
            _clientService = clientService;
            _bookService = bookService;
        }

        /// <summary>
        /// This is a asynchronous function that creates a new Book.
        /// </summary>
        public async Task<Borrow> BorrowBook(Borrow borrow, Book book, Client client)
        {
            Borrow newBorrow = new Borrow()
            {
                BorrowedDate = borrow.BorrowedDate,
                ClientId = client.Id,
                BookId = book.Id
            };

            await _borrowService.Create(newBorrow);
            await _bookService.Update(book.Id, book);
            await _clientService.Update(client.Id, client);
            return newBorrow;
        }
        /// <summary>
        /// This is a function that returns all Borrows.
        /// </summary>
        /// <returns>
        /// Returns all Borrows in the database.
        /// </returns>
        public ICollection<Borrow> GetBorrows()
        {
            ICollection<Borrow> borrows = _borrowService.GetAll();
            return borrows;
        }
    }
}
