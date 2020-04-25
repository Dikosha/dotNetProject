using Microsoft.EntityFrameworkCore;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       
    }
}
