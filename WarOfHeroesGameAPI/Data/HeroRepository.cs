using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WarOfHeroesGameAPI.Data.Entities;

namespace WarOfHeroesGameAPI.Data
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        public Hero GetHeroById(int id)
        {
            return _context.Heroes.Include(h => h.Ability).FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hero> GetHeroesById(IEnumerable<int> ids)
        {
            return ids.Select(id => _context.Heroes.Include(h => h.Ability).FirstOrDefault(h => h.Id == id));
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _context.Heroes.Include(h => h.Ability).ToList();
        }

        public IEnumerable<Hero> GetRandomHeroes(int amount)
        {
            var random = new Random();
            int max = _context.Heroes.Count();
            for (var i = 0; i < amount; i++)
            {
                var next = random.Next(1, max);
                yield return _context.Heroes.SingleOrDefault(x => x.Id == next);
            }
        }
    }
}