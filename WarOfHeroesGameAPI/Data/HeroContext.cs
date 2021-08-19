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
        public virtual DbSet<Ability> Ability { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_config.GetConnectionString("HeroDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>().HasData(GetData<Hero>("./Data/Seeding/heroes.json"));
            modelBuilder.Entity<Ability>().HasData(GetData<Ability>("./Data/Seeding/abilities.json"));
        }
        private static IEnumerable<T> GetData<T>(string filepath) {
;
            var json = File.ReadAllText(filepath);
            var data = JsonSerializer.Deserialize<IEnumerable<T>>(json);

            return data;
        }
    }
}
