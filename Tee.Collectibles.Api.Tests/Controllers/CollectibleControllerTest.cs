using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Tee.Collectibles.Api.Controllers;
using Tee.Collectibles.Api.IServices;
using Tee.Collectibles.Common.Entities;

namespace Tee.Collectibles.Api.Tests.Controllers
{
    [TestFixture]
    public class CollectibleControllerTest
    {
        private ICollectibleService collectableService;
        private CollectibleController controller;
        private List<Collectible> collectibles;

        [SetUp]
        public void Setup()
        {
            this.collectableService = Substitute.For<ICollectibleService>();
            this.controller = new CollectibleController(this.collectableService);
            this.collectibles = new List<Collectible>
            {
                new Collectible {Id = 1, Title = "First"},
                new Collectible {Id = 2, Title = "Second"},
            };
        }

        [Test]
        public void Get_Returns_AListOfCollectibles_GivenNoParameter()
        {
            // Arrange

            this.collectableService.GetAll().Returns(collectibles.AsEnumerable());

            // Act
            var result = controller.Get().ToList();

            // Assert
            result.Should().NotBeNull();
            result.Count().ShouldBeEquivalentTo(2);
        }

        [Test]
        public void Get_Returns_Collectible_GivenAnId()
        {
            // Arrange
            var id = 1;
            this.collectableService.Get(id).Returns(collectibles.First(c => c.Id == id));

            // Act
            var result = controller.Get(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.ShouldBeEquivalentTo(id);
        }

        [Test]
        public void Post()
        {
            // Arrange
            var collectible = new Collectible();
            this.collectableService.Add(collectible).Returns(3);

            // Act
            var result = controller.Post(collectible);

            // Assert
            result.ShouldBeEquivalentTo(3);
        }

        [Test]
        public void Put()
        {
            // Arrange
            var collectible = new Collectible();

            // Act
            controller.Put(collectible);

            // Assert
            this.collectableService.Received(1).Update(collectible);
        }

        [Test]
        public void Delete()
        {
            // Arrange
            var id = 1;
            this.collectableService.Get(1).Returns(this.collectibles.First(c => c.Id == id));

            // Act
            controller.Delete(1);

            // Assert
            this.collectableService.Received(1).Delete(this.collectibles.First(c => c.Id == id));
        }
    }
}