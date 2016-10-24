using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Tee.Collectables.Services;
using Tee.Collectibles.Common.Entities;
using Tee.Collectibles.Common.Repository;

namespace Tee.Collectibles.Api.Tests.Services
{
    [TestFixture]
    internal class CollectibleServiceTests : BaseCollectibleTests
    {
        private IRepository<Collectible> _collectibleRepository;
        private CollectibleService _sut;

        [SetUp]
        public void Setup()
        {
            this._collectibleRepository = Substitute.For<IRepository<Collectible>>();
            this._sut = new CollectibleService(_collectibleRepository);

            this._collectibleRepository.GetAll().Returns(this.Collectibles);
        }

        [Test]
        public void GetAllCollectibles_ReturnAllCollectibles()
        {
            // Arrage
            // Act

            var result = this._sut.GetAllCollectibles().ToList();

            // Assert
            result.Count.ShouldBeEquivalentTo(2);
        }

        [Test]
        public void GetCollectibleById_GivenAValidId_ReturnCollectibles()
        {
            // Arrage
            const int id = 1;
            this._collectibleRepository.Get(1).Returns(this.Collectibles.First(c => c.Id == id));

            // Act
            var result = this._sut.GetCollectibleById(id);

            // Assert
            result.Id.ShouldBeEquivalentTo(id);
        }

        [Test]
        public void Update_GivenAValidCOllectible_Updates()
        {
            // Arrage
            var data = new Collectible { Id = 1, Title = "Updated First" };

            // Act
            this._sut.Update(data);

            // Assert
            this._collectibleRepository.Received(1).Update(data);
        }

        [Test]
        public void Delete_GivenAValidCollectible_Deletes()
        {
            // Arrage
            var data = new Collectible { Id = 1, Title = "Updated First" };

            // Act
            this._sut.Delete(data);

            // Assert
            this._collectibleRepository.Received(1).Delete(data);
        }

        [Test]
        public void Add_GivenAValidCollectible_Inserts()
        {
            // Arrage
            var data = new Collectible { Id = 1, Title = "Updated First" };

            // Act
            this._sut.Add(data);

            // Assert
            this._collectibleRepository.Received(1).Insert(data);
        }
    }
}