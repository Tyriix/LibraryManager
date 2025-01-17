﻿using System;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is a Borrow model.
    /// </summary>
    public class Borrow : DomainObject
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }

        public int BookId { get; set; }
        public int ClientId { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}
