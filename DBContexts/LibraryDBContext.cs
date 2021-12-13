using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library2021GPD.Models;

namespace Library2021GPD.DBContexts
{
    class LibraryDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<AuthorBook> AuthorBooks { get; set; }

        public LibraryDBContext(): base("name=LibraryDBContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().ToTable("Authors").HasKey(a => new { a.AuthorId });
            modelBuilder.Entity<Book>().ToTable("Books").HasKey(b => new { b.BookId });
            modelBuilder.Entity<AuthorBook>().ToTable("Author_Book").HasKey(x => new { x.AuthorId, x.BookId});
        }
    }
}
