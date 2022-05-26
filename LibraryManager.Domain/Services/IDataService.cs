using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Services
{
    public interface IDataService<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id,T entity);
        Task<bool> Delete(int id);
    }
}
