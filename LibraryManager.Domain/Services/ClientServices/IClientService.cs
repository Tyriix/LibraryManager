using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services.ClientServices
{
    public interface IClientService
    {
        ICollection<Client> GetClients();
        Task<Client> AddClient(Client client);
    }
}
