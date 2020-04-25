using Microsoft.EntityFrameworkCore;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Contexts
{
    public class AuthorContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public AuthorContext(DbContextOptions<AuthorContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
        }

    }
}
