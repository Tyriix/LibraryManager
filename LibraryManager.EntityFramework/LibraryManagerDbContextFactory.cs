using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace LibraryManager.EntityFramework
{
    /// <summary>
    /// This is a class for connecting the application to SqlServer.
    /// </summary>
    public class LibraryManagerDbContextFactory : IDesignTimeDbContextFactory<LibraryManagerDbContext>
    {
        public LibraryManagerDbContext CreateDbContext(string[] args = null)
        {
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            var options = new DbContextOptionsBuilder<LibraryManagerDbContext>();
            options.UseSqlite($"Data Source=/{dbPath}/LMDatabase.db");
            return new LibraryManagerDbContext(options.Options);
        }
    }
}
