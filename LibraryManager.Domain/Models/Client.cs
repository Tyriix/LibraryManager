using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Domain.Models
{
    /// <summary>
    /// This is a Client model.
    /// </summary>
    public class Client : DomainObject
    {
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Address { get; set; }
        [StringLength(9, ErrorMessage = "The number must me 9 digits long.")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
