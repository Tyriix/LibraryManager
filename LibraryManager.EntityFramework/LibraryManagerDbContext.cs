using LibraryManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.EntityFramework
{
    /// <summary>
    /// This is a class for setting Database Sets.
    /// </summary>
    public class LibraryManagerDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public LibraryManagerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
