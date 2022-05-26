using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.EntityFramework
{
    public class DesignTimeDbContextOptions : IDesignTimeDbContextFactory<LibraryManagerDbContext>
    {
        public LibraryManagerDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<LibraryManagerDbContext>();
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibraryManagerDb;Trusted_Connection=True");

            return new LibraryManagerDbContext(options.Options);
        }
    }
}
