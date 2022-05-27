using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.Services
{
    public class LibrarianDataService : IDataService<Librarian>
    {
        private readonly LibraryManagerDbContextFactory _contextFactory;
        public LibrarianDataService(LibraryManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Librarian> Create(Librarian entity)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<Librarian> createdResult = await context.Librarians.AddAsync(entity);
            await context.SaveChangesAsync();


            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            Librarian entity = await context.Librarians.FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<Librarian>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Librarian> Get(int id)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            Librarian entity = await context.Librarians.Include(a => a.Borrows).FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
        }

        public async Task<ICollection<Librarian>> GetAll()
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            ICollection<Librarian> entities = await context.Librarians.ToListAsync();

            return entities;
        }

        public async Task<Librarian> Update(int id, Librarian entity)
        {
            using LibraryManagerDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Librarians.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
