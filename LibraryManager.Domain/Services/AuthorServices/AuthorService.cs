using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IDataService<Author> _authorService;

        public AuthorService(IDataService<Author> authorService)
        {
            _authorService = authorService;
        }

        public Task<Author> AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }
        public ICollection<Author> GetAuthors()
        {
            ICollection<Author> authors = _authorService.GetAll();
            return authors;
        }
    }
}
