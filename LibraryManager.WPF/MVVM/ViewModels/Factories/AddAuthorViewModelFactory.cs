using LibraryManager.Domain.Services.AuthorServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddAuthorViewModelFactory : ILibraryManagerViewModelFactory<AddAuthorViewModel>
    {
        private IAuthorService AddAuthorService { get; set; }

        public AddAuthorViewModelFactory(IAuthorService addClientService)
        {
            AddAuthorService = addClientService;
        }

        public AddAuthorViewModel CreateViewModel()
        {
            return new AddAuthorViewModel(AddAuthorService);
        }
    }
}
