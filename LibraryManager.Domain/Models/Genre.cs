using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
