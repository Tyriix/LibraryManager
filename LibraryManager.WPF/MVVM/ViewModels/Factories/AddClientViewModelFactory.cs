using LibraryManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddClientViewModelFactory : ILibraryManagerViewModelFactory<AddClientViewModel>
    {
        private IAddClientService addClientService { get; set; }

        public AddClientViewModelFactory(IAddClientService addClientService)
        {
            this.addClientService = addClientService;
        }

        public AddClientViewModel CreateViewModel()
        {
            return new AddClientViewModel(addClientService);
        }
    }
}
