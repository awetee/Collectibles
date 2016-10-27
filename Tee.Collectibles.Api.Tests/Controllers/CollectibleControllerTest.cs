using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Tee.Collectibles.Api.Controllers;
using Tee.Collectibles.Common.Entities;
using Tee.Collectibles.Common.Services;

namespace Tee.Collectibles.Api.Tests.Controllers
{
    [TestFixture]
    public class CollectibleControllerTest : BaseCollectibleTests
    {
        private ICollectibleService _collectableService;
        private CollectibleController _controller;

        [SetUp]
        public void Setup()
        {
            this._collectableService = Substitute.For<ICollectibleService>();
            this._controller = new CollectibleController(this._collectableService);
        }

        [Test]
        public void Get_Returns_AListOfCollectibles_GivenNoParameter()
        {
            // Arrange

            this._collectableService.GetAllCollectibles().Returns(Collectibles.AsEnumerable());

            // Act
            var actionResult = _controller.Get();

            // Assert
            var result = actionResult as OkNegotiatedContentResult<IEnumerable<Collectible>>;
            result.Content.Should().NotBeNull();
            result.Content.Count().ShouldBeEquivalentTo(2);
        }

        [Test]
        public void Get_Returns_Collectible_GivenAnId()
        {
            // Arrange
            var id = 1;
            this._collectableService.GetCollectibleById(id).Returns(Collectibles.First(c => c.Id == id));

            // Act
            var actionResult = _controller.Get(id);

            // Assert
            var result = actionResult as OkNegotiatedContentResult<Collectible>;
            result.Content.Should().NotBeNull();
            result.Content.Id.ShouldBeEquivalentTo(id);
        }

        [Test]
        public void Post()
        {
            // Arrange
            var collectible = new Collectible();
            this._collectableService.Add(collectible).Returns(3);

            // Act
            var actionResult = _controller.Post(collectible);
            var result = actionResult as OkNegotiatedContentResult<int>;

            // Assert
            result.Content.ShouldBeEquivalentTo(3);
        }

        [Test]
        public void Put()
        {
            // Arrange
            var collectible = new Collectible();

            // Act
            _controller.Put(collectible);

            // Assert
            this._collectableService.Received(1).Update(collectible);
        }

        [Test]
        public void Delete()
        {
            // Arrange
            var id = 1;
            this._collectableService.GetCollectibleById(1).Returns(this.Collectibles.First(c => c.Id == id));

            // Act
            _controller.Delete(1);

            // Assert
            this._collectableService.Received(1).Delete(this.Collectibles.First(c => c.Id == id));
        }
    }
}