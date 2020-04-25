using Microsoft.EntityFrameworkCore;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Contexts
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
