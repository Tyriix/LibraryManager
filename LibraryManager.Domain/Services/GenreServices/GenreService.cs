using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManager.Domain.Services.GenreServices
{
    /// <summary>
    /// This is a service for managing Genre data.
    /// It's used to Add a Genre or Return all Genres.
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IDataService<Genre> _genreService;

        public GenreService(IDataService<Genre> genreService)
        {
            _genreService = genreService;
        }
        /// <summary>
        /// This is a asynchronous function that creates a new Genre.
        /// </summary>
        public async Task<Genre> AddGenre(Genre genre)
        {
            Genre newGenre = new Genre()
            {
                Name = genre.Name
            };
            var allGenres = _genreService.GetAll();
            foreach (var item in allGenres)
            {
                if (item.Name == newGenre.Name)
                {
                    MessageBox.Show("This genre already exists");
                    return newGenre;
                }
            }
            await _genreService.Create(newGenre);
            MessageBox.Show("New genre added.");
            return newGenre;
        }
        /// <summary>
        /// This is a function that returns all Genres.
        /// </summary>
        /// <returns>
        /// Returns all Genres in the database.
        /// </returns>
        public ICollection<Genre> GetGenres()
        {
            ICollection<Genre> genres = _genreService.GetAll();
            return genres;
        }
    }
}
