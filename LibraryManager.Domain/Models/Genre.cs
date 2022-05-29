using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is a Genre model.
    /// </summary>
    public class Genre : DomainObject
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
