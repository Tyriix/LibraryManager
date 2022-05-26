using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
    }
}
