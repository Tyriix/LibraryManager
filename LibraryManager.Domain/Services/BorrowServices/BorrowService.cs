using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BorrowServices
{
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

        public ICollection<Borrow> GetBorrows()
        {
            ICollection<Borrow> borrows = _borrowService.GetAll();
            return borrows;
        }
    }
}
