using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManager.EntityFramework
{
    public class LibraryManagerDbContextFactory : IDesignTimeDbContextFactory<LibraryManagerDbContext>
    {
        public LibraryManagerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<LibraryManagerDbContext>();
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibraryManagerDb;Trusted_Connection=True");

            return new LibraryManagerDbContext(options.Options);
        }
    }
}
