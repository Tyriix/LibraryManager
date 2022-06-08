using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Domain
{
    // <summary>
    // This is an interface for managing CRUD for all models.
    // </summary>
    public interface IDataService<T>
    {
        ICollection<T> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
