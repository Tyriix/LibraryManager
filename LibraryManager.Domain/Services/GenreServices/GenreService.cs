using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly IDataService<Genre> _genreService;

        public GenreService(IDataService<Genre> genreService)
        {
            _genreService = genreService;
        }
        public async Task<Genre> AddGenre(Genre genre)
        {
            Genre newGenre = new Genre()
            {
                Name = genre.Name
            };
            await _genreService.Create(newGenre);
            return newGenre;
        }

        public ICollection<Genre> GetGenres()
        {
            ICollection<Genre> genres = _genreService.GetAll();
            return genres;
        }
    }
}
