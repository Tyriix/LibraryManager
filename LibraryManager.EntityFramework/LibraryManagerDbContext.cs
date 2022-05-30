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
            modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Borrow>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Genre>().Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(a => a.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
