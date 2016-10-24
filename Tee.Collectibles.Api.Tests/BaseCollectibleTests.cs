namespace Tee.Collectibles.Api.Tests
{
    using System.Collections.Generic;
    using Tee.Collectibles.Common.Entities;

    public abstract class BaseCollectibleTests
    {
        protected List<Collectible> Collectibles;

        protected BaseCollectibleTests()
        {
            this.Collectibles = new List<Collectible>
            {
                new Collectible {Id = 1, Title = "First"},
                new Collectible {Id = 2, Title = "Second"}
            };
        }
    }
}