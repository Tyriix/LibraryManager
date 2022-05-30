using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.AuthorServices;
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
        public ICommand GetAuthors { get; set; }

        public AuthorsViewModel()
        {
            IAuthorService getClientsService = new AuthorService(dataService);
            var authors = getClientsService.GetAuthors();

            _authors = new ObservableCollection<Author>(authors);
        }
    }
}
