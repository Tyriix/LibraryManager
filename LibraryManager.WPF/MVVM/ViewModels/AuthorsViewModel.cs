using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels
{
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
