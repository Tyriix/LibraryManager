using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    public class Librarian : DomainObject
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
