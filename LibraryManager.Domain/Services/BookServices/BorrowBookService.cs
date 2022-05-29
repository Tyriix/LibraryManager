using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.BookServices
{
    public class BorrowBookService : IBorrowBookService
    {
        private readonly IDataService<Borrow> _borrowService;

        public BorrowBookService(IDataService<Borrow> borrowService)
        {
            _borrowService = borrowService;
        }

        public async Task<Borrow> AddClient(Borrow borrow)
        {
            Borrow newBorrow = new Borrow()
            {
                BorrowedDate = DateTime.Now,

            };
            await _borrowService.Create(newBorrow);
            return newBorrow;
        }
    }
}
