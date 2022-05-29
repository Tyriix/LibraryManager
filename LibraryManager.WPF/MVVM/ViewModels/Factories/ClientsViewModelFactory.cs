using LibraryManager.Domain.Services.ClientServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class ClientsViewModelFactory : ILibraryManagerViewModelFactory<ClientsViewModel>
    {
        public ClientsViewModel CreateViewModel()
        {
            return new ClientsViewModel();
        }
    }
}
