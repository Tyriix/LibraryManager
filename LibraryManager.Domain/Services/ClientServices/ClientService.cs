using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

            if (newClient.FirstName.Any(ch => !Char.IsLetterOrDigit(ch)) == true
                || newClient.LastName.Any(ch => !Char.IsLetterOrDigit(ch)) == true
                || newClient.City.Any(ch => !Char.IsLetterOrDigit(ch)) == true)
            {
                MessageBox.Show("First name, last name or city can't contain numbers or special signs, try again.");
                return newClient;
            }

            var allClients = _clientService.GetAll();
            foreach (var item in allClients)
            {
                if (item.FirstName == newClient.FirstName 
                    && item.LastName == newClient.LastName
                    && item.City == newClient.City
                    && item.Address == newClient.Address
                    && item.Phone == newClient.Phone
                    && item.Email == newClient.Email)
                {
                    MessageBox.Show("This client already exists");
                    return newClient;
                }
            }
            await _clientService.Create(newClient);
            MessageBox.Show("New client added.");
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
