using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{

    /// <summary>
    /// This is a viewModel class for Clients View.
    /// </summary>
    public class ClientsViewModel : ViewModelBase
    {
        readonly IDataService<Client> dataService = new GenericDataService<Client>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Client> _clients;
        public ICollection<Client> Clients => _clients;

        public ClientsViewModel()
        {
            var clients = dataService.GetAll();

            _clients = new ObservableCollection<Client>(clients);
        }
    }
}
