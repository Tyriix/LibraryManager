using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly IDataService<Genre> _genreService;

        public GenreService(IDataService<Genre> genreService)
        {
            _genreService = genreService;
        }

        public ICollection<Genre> GetGenres()
        {
            ICollection<Genre> genres = _genreService.GetAll();
            return genres;
        }
    }
}
