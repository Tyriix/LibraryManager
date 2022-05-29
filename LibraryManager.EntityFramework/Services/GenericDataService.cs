using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.Services
{
    /// <summary>
    /// This is a class for managing Generic data.
    /// It's used to Create, Delete, Get by Id, GetAll and Update a Generic Object.
    /// </summary>
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly LibraryManagerDbContextFactory _contextFactory;
        public GenericDataService(LibraryManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();


            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<T> Get(int id)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
        }

        public  ICollection<T> GetAll()
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();

            List<T> entities = new List<T>();
            foreach (var item in context.Set<T>())
            {
                entities.Add(item);
            }
            

            return entities;
        }

        public async Task<T> Update(int id, T entity)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
