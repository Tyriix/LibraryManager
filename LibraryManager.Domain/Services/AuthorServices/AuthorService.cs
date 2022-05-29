using LibraryManager.Domain.Models;
using System.Collections.Generic;
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
        public async Task<Author> AddAuthor(Author author)
        {
            Author newAuthor = new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
            await _authorService.Create(newAuthor);
            return newAuthor;
        }
        public ICollection<Author> GetAuthors()
        {
            ICollection<Author> authors = _authorService.GetAll();
            return authors;
        }
    }
}
