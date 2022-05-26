using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Models
{
    public class Librarian
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<Borrow> Borrows { get; set; }
    }
}
