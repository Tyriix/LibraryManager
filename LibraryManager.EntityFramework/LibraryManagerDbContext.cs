﻿using LibraryManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.EntityFramework
{
    public class LibraryManagerDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public LibraryManagerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Genre>().HasMany(g => g.Books).WithOne(g => g.Genre).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>().HasMany(c => c.Borrow).WithOne(b => b.Book);

            modelBuilder.Entity<Client>().HasMany(c => c.Borrows).WithOne(b => b.Client).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Librarian>().HasMany(c => c.Borrows).WithOne(b => b.Librarian).OnDelete(DeleteBehavior.Cascade);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}