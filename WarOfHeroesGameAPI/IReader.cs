using System.Collections.Generic;

namespace WarOfHeroesGameAPI
{
    public interface IReader
    {
        public IEnumerable<Hero> ReadAllHeroes();
    }
}