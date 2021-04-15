using System.Collections.Generic;
using System.IO;

namespace WarOfHeroesGameAPI
{
    public class HeroReader : IReader
    {
        private readonly string _filePath;

        public HeroReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Hero> ReadAllHeroes()
        {
            using var sr = new StreamReader(_filePath);
            var heroes = new List<Hero>();

            // Read CSV header
            sr.ReadLine();

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                heroes.Add(ReadHeroFromCsvLine(line));
            }

            return heroes;
        }

        private Hero ReadHeroFromCsvLine(string line)
        {
            var parts = line.Split(',');

            return new Hero
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                AttackDamage = int.Parse(parts[2]),
                DefenseAmount = int.Parse(parts[3])
            };
        }
    }
}