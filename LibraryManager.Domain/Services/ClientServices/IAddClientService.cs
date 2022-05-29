using LibraryManager.Domain.Models;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    public interface IAddClientService
    {
        Task<Client> AddClient(Client client);
    }
}
