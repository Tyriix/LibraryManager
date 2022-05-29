using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.GenreServices
{
    public class AddGenreService : IAddGenreService
    {
        private readonly IDataService<Genre> _genreService;

        public AddGenreService(IDataService<Genre> genreService)
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
    }
}
