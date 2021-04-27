using System.Collections.Generic;
using WarOfHeroesGameAPI.Data.Entities;

namespace WarOfHeroesGameAPI.Data
{
    public interface IHeroRepository
    {
        Hero GetHeroById(int id);
        IEnumerable<Hero> GetHeroesById(IEnumerable<int> ids);
        IEnumerable<Hero> GetAllHeroes();
    }
}