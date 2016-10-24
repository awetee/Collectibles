using System;
using NUnit.Framework;
using Tee.Collectables.Services.Extensions;

namespace Tee.Collectibles.Api.Tests.Extensions
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void AgainstNullTest()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Guard.AgainstNull(null, "Null");
            });
        }
    }
}