using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WarOfHeroesGameAPI.Controllers
{
    [Route("hero")]
    [ApiController]
    public class HeroController
    {
        private readonly IReader _reader;

        public HeroController(IReader reader)
        {
            _reader = reader;
        }

        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _reader.ReadAllHeroes();
        }

        [Route("/hero/{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var heroes = _reader.ReadAllHeroes();

            var heroToReturn = heroes.SingleOrDefault(h => h.Id == id);

            if (heroToReturn == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(heroToReturn);
        }
    }
}
