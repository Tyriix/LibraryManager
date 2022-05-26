using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }
        public Librarian Librarian { get; set; }
    }
}
