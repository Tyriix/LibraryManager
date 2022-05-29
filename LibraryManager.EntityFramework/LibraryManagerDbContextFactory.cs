using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManager.EntityFramework
{
    /// <summary>
    /// This is a class for connecting the application to SqlServer.
    /// </summary>
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
