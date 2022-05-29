using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Services.GenreServices
{
    public interface IGenreService
    {
        ICollection<Genre> GetGenres();
    }
}
