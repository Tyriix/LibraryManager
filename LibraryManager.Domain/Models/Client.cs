﻿using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    public class Client : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Borrow> Borrows { get; set; }

        public override string ToString()
        {
            return FirstName + " " + Phone;
        }
    }
}
