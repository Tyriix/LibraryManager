using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.ClientServices;
using LibraryManager.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{

    public class ClientsViewModel : ViewModelBase
    {
        readonly IDataService<Client> dataService = new GenericDataService<Client>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Client> _clients;

        public ICollection<Client> Clients => _clients;
        public ICommand GetClients { get; set; }

        public ClientsViewModel()
        {
            IClientService getClientsService = new ClientService(dataService);
            var clients = getClientsService.GetClients();

            _clients = new ObservableCollection<Client>(clients);
        }
    }
}
