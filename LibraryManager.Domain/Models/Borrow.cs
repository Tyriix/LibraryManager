using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public int LibrarianId { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}
