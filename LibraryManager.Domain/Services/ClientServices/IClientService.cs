using LibraryManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    /// <summary>
    /// This is an interface for managing Client data.
    /// </summary>
    public interface IClientService
    {
        ICollection<Client> GetClients();
        Task<Client> AddClient(Client client);
    }
}
