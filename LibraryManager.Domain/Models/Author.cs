using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is an Author model.
    /// </summary>
    public class Author : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
