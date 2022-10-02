using System;
using Microsoft.EntityFrameworkCore;
using TravelApp.Models;

namespace TravelApp.Data
{
    public class CountryContext : DbContext 
    {
        public CountryContext (DbContextOptions<CountryContext> options) : base(options)
        {
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>().ToTable("Continent");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Town>().ToTable("Town");
            modelBuilder.Entity<Description>().ToTable("Description");
        }

    }
}