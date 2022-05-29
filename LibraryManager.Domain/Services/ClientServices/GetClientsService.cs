using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    public class GetClientsService : IGetClientsService
    {
        private readonly IDataService<Client> _clientService;

        public GetClientsService(IDataService<Client> clientService)
        {
            _clientService = clientService;
        }

        public ICollection<Client> GetClients()
        {
            ICollection<Client> clients = _clientService.GetAll();
            return clients;
        }
    }
}
