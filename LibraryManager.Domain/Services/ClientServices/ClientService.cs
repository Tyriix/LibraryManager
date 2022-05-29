using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IDataService<Client> _clientService;

        public ClientService(IDataService<Client> clientService)
        {
            _clientService = clientService;
        }
        public async Task<Client> AddClient(Client client)
        {
            Client newClient = new Client()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                City = client.City,
                Address = client.Address,
                Phone = client.Phone,
                Email = client.Email
            };
            await _clientService.Create(newClient);
            return newClient;
        }
        public ICollection<Client> GetClients()
        {
            ICollection<Client> clients = _clientService.GetAll();
            return clients;
        }
        
    }
}
