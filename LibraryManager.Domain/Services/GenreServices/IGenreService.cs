using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.GenreServices
{
    public interface IGenreService
    {
        ICollection<Genre> GetGenres();
        Task<Genre> AddGenre(Genre genre);
    }
}
