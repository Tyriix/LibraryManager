using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    /// <summary>
    /// This is a service for managing Client data.
    /// It's used to Add a Client or Return all Clients.
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IDataService<Client> _clientService;

        public ClientService(IDataService<Client> clientService)
        {
            _clientService = clientService;
        }
        /// <summary>
        /// This is a asynchronous function that creates a new Client.
        /// </summary>
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
        /// <summary>
        /// This is a function that returns all Clients.
        /// </summary>
        /// <returns>
        /// Returns all Clients in the database.
        /// </returns>
        public ICollection<Client> GetClients()
        {
            ICollection<Client> clients = _clientService.GetAll();
            return clients;
        }
        
    }
}
