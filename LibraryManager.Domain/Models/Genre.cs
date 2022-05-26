using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    public class Genre : DomainObject
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
