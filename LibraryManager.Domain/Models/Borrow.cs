﻿using System;

namespace LibraryManager.Domain.Models
{
    public class Borrow : DomainObject
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }
        public Librarian Librarian { get; set; }
    }
}
