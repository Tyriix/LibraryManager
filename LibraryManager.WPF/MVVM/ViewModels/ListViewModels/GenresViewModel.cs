using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{
    public class GenresViewModel : ViewModelBase
    {
        readonly IDataService<Genre> dataService = new GenericDataService<Genre>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Genre> _genres;

        public ICollection<Genre> Genres => _genres;
        public ICommand GetGenres { get; set; }

        public GenresViewModel()
        {
            IGenreService getClientsService = new GenreService(dataService);
            var genres = getClientsService.GetGenres();

            _genres = new ObservableCollection<Genre>(genres);
        }
    }
}
