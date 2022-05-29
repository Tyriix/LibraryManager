using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.AuthorServices
{
    /// <summary>
    /// This is a service for managing Author data.
    /// It's used to Add an Author or Return all Authors.
    /// </summary>
    public class AuthorService : IAuthorService
    {

        private readonly IDataService<Author> _authorService;

        public AuthorService(IDataService<Author> authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// This is a asynchronous function that creates a new Author.
        /// </summary>
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
        /// <summary>
        /// This is a function that returns all Authors.
        /// </summary>
        /// <returns>
        /// Returns all authors in the database.
        /// </returns>
        public ICollection<Author> GetAuthors()
        {
            ICollection<Author> authors = _authorService.GetAll();
            return authors;
        }
    }
}
