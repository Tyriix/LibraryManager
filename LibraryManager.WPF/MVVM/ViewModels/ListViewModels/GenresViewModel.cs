using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{
    /// <summary>
    /// This is a viewModel class for Genres View.
    /// </summary>
    public class GenresViewModel : ViewModelBase
    {
        readonly IDataService<Genre> dataService = new GenericDataService<Genre>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Genre> _genres;
        public ICollection<Genre> Genres => _genres;

        public GenresViewModel()
        {
            var genres = dataService.GetAll();

            _genres = new ObservableCollection<Genre>(genres);
        }
    }
}
