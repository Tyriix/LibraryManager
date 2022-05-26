﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
