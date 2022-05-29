using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.AuthorServices
{
    public interface IAuthorService
    {
        ICollection<Author> GetAuthors();
        Task<Author> AddAuthor(Author author);
    }
}
