using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using WarOfHeroesGameAPI.Controllers;
using WarOfHeroesGameAPI.Data;
using WarOfHeroesGameAPI.Data.Entities;

namespace WarOfHeroesGameAPI.Tests.Controllers
{
    [TestFixture]
    public class HeroControllerTests
    {
        [SetUp]
        public void Setup()
        {
            _fakeHeroRepository = A.Fake<IHeroRepository>();
            _controller = new HeroController(_fakeHeroRepository, A.Fake<ILogger<HeroController>>());
        }

        private HeroController _controller;
        private IHeroRepository _fakeHeroRepository;

        [Test]
        public void TestControllerGetsAllHeroes()
        {
            var heroes = new List<Hero>
            {
                new Hero(),
                new Hero()
            };

            A.CallTo(() => _fakeHeroRepository.GetAllHeroes()).Returns(heroes);
            var result = (ObjectResult) _controller.Get();
            var dataResult = (IEnumerable<Hero>) result.Value;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, dataResult.Count());
        }

        [Test]
        public void TestControllerReturnsBadRequestWhenExceptionThrown()
        {
            A.CallTo(() => _fakeHeroRepository.GetAllHeroes()).Throws<Exception>();

            var result = (ObjectResult) _controller.Get();

            A.CallTo(() => _fakeHeroRepository.GetAllHeroes()).MustHaveHappenedOnceExactly();
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void TestControllerGetsHeroById()
        {
            var heroToReturn = new Hero();
            A.CallTo(() => _fakeHeroRepository.GetHeroById(1)).Returns(heroToReturn);

            var result = (ObjectResult) _controller.Get(1);
            var heroReturned = (Hero) result.Value;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(heroToReturn, heroReturned);
        }

        [Test]
        public void TestControllerGetHeroByIdReturnsNotFoundIfHeroDoesNotExist()
        {
            A.CallTo(() => _fakeHeroRepository.GetHeroById(100)).Returns(null);

            var result = (ObjectResult) _controller.Get(100);

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void TestControllerGetHeroByIdReturnsBadRequestWhenExceptionThrown()
        {
            A.CallTo(() => _fakeHeroRepository.GetHeroById(-1)).Throws<Exception>();

            var result = (ObjectResult) _controller.Get(-1);

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void TestControllerGetHeroesByIdReturnsListOfHeroes()
        {
            var heroesToReturn = new List<Hero>
            {
                new Hero(),
                new Hero(),
                new Hero()
            };

            var ids = new List<int> {1, 2, 3};

            var heroesRequest = new HeroesRequest
            {
                HeroIds = ids
            };

            A.CallTo(() => _fakeHeroRepository.GetHeroesById(ids)).Returns(heroesToReturn);

            var result = (ObjectResult) _controller.Get(heroesRequest);
            var returnedData = (IEnumerable<Hero>) result.Value;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(3, returnedData.Count());
        }

        [Test]
        public void TestControllerGetHeroesByIdReturnsListOfHeroesAndExcludesHeroesNotFound()
        {
            var heroesToReturn = new List<Hero>
            {
                new Hero(),
                new Hero(),
                new Hero()
            };

            var ids = new List<int> {1, 2, 3, 4, 5};

            var heroesRequest = new HeroesRequest
            {
                HeroIds = ids
            };

            A.CallTo(() => _fakeHeroRepository.GetHeroesById(ids)).Returns(heroesToReturn);

            var result = (ObjectResult) _controller.Get(heroesRequest);
            var returnedData = (IEnumerable<Hero>) result.Value;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(3, returnedData.Count());
        }

        [Test]
        public void TestControllerGetHeroesByIdReturnsNotFoundIfNoHeroesExist()
        {
            var heroesToReturn = new List<Hero>();
            var ids = new List<int> {100, 200};

            var heroesRequest = new HeroesRequest
            {
                HeroIds = ids
            };

            A.CallTo(() => _fakeHeroRepository.GetHeroesById(ids)).Returns(heroesToReturn);

            var result = (ObjectResult) _controller.Get(heroesRequest);

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void TestControllerGetHeroesByIdReturnsBadRequestWhenExceptionThrown()
        {
            var ids = new List<int> {100, 200};

            var heroesRequest = new HeroesRequest
            {
                HeroIds = ids
            };

            A.CallTo(() => _fakeHeroRepository.GetHeroesById(ids)).Throws<Exception>();

            var result = (ObjectResult) _controller.Get(heroesRequest);

            Assert.AreEqual(400, result.StatusCode);
        }
    }
}