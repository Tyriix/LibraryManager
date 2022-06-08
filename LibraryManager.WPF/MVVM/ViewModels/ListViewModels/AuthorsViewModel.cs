using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework.Services;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{
    /// <summary>
    /// This is a viewModel class for Authors View.
    /// </summary>
    public class AuthorsViewModel : ViewModelBase
    { 
        
        readonly IDataService<Author> dataService = new GenericDataService<Author>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Author> _authors;
        public ICollection<Author> Authors => _authors;

        public AuthorsViewModel()
        {
            var authors = dataService.GetAll();

            _authors = new ObservableCollection<Author>(authors);
        }
    }
}
