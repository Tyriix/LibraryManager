using System.Collections.Generic;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is a Client model.
    /// </summary>
    public class Client : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
