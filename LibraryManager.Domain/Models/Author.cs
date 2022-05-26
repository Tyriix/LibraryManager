using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    public class Author : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
