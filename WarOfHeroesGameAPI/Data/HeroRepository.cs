using System.Collections.Generic;
using System.Linq;
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
            return _context.Heroes.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hero> GetHeroesById(IEnumerable<int> ids)
        {
            return _context.Heroes.Where(h => ids.Contains(h.Id)).ToList();
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _context.Heroes.ToList();
        }
    }
}