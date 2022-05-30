using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

            if (newAuthor.FirstName.Any(ch => !char.IsLetter(ch)) == true
                || newAuthor.LastName.Any(ch => !char.IsLetter(ch)) == true)
            {
                MessageBox.Show("First name or last name can't contain numbers or special signs, try again.");
                return newAuthor;
            }
            var allAuthors = _authorService.GetAll();
            foreach (var item in allAuthors)
            {
                if (item.FirstName == newAuthor.FirstName
                    && item.LastName == newAuthor.LastName)
                {
                    MessageBox.Show("This author already exists");
                    return newAuthor;
                }
            }       
            
            await _authorService.Create(newAuthor);
            MessageBox.Show("New author added.");
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
