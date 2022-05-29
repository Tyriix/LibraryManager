using System;
using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is a Book model.
    /// </summary>
    public class Book : DomainObject
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
    }
}
