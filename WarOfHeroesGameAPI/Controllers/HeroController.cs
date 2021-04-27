using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarOfHeroesGameAPI.Data;

namespace WarOfHeroesGameAPI.Controllers
{
    [Route("hero")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;
        private readonly IHeroRepository _repository;

        public HeroController(IHeroRepository repository, ILogger<HeroController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [Route("/")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllHeroes());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get all heroes from Get() endpoint");
                return BadRequest("Failed to get Heroes");
            }
        }

        [Route("/hero/{id}")]
        [HttpGet]
        public ActionResult Get([FromRoute] int id)
        {
            try
            {
                var hero = _repository.GetHeroById(id);

                if (hero == null)
                {
                    return NotFound($"Unable to find hero with ID: {id}");
                }

                return Ok(hero);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred trying to retrieve Hero with ID: {id}", id);
                return BadRequest($"An error occurred trying to retrieve Hero with ID: {id}");
            }
        }

        [Route("/hero/ids")]
        [HttpPost]
        public ActionResult Get([FromBody] HeroesRequest heroIds)
        {
            try
            {
                var heroes = _repository.GetHeroesById(heroIds.HeroIds);

                if (heroes == null || !heroes.Any())
                {
                    return NotFound("Unable to find requested Heroes");
                }

                return Ok(heroes);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred trying to retrieve heroes with IDs: {ids}", heroIds.HeroIds);
                return BadRequest("An error occurred trying to retrieve heroes");
            }
        }
    }
}