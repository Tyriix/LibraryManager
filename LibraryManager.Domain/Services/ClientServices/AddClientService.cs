using LibraryManager.Domain.Models;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    public class AddClientService : IAddClientService
    {
        private readonly IDataService<Client> _clientService;

        public AddClientService(IDataService<Client> clientService)
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
    }
}
