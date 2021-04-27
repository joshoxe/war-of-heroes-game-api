using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WarOfHeroesGameAPI.Data.Entities;

namespace WarOfHeroesGameAPI.Data
{
    public class HeroContext : DbContext
    {
        private readonly IConfiguration _config;

        public HeroContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Hero> Heroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_config.GetConnectionString("HeroDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>().HasData(GetData());
        }
        private static IEnumerable<Hero> GetData() {

            const string filePath = "./Data/Seeding/heroes.json";
            var json = File.ReadAllText(filePath);
            var heroes = JsonSerializer.Deserialize<IEnumerable<Hero>>(json);

            return heroes;
        }
    }
}
