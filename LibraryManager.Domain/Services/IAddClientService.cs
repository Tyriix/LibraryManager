using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services
{
    public interface IAddClientService
    {
        Task<Client> AddClient(Client client);
    }
}
