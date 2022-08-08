using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EducationAPI.Data.Entities;
using EducationAPI.Data.Context.Seeder;

namespace EducationAPI.Data.Context
{
    public class EducationAPIContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<MaterialType> MaterialTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EducationAPI;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.EducationSeedDatabase();
        }


    }
}
