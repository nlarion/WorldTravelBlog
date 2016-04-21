using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public class TravelBlogDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<People> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security = True");
        }
    }
}
