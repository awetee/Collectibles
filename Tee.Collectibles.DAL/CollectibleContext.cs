namespace Tee.Collectibles.DAL
{
    using System.Data.Entity;
    using Tee.Collectibles.DAL.Entities;

    public class CollectibleContext : DbContext
    {
        public CollectibleContext() : base("CollectiblesContext")
        {
        }

        public DbSet<Collectible> Collectibles { get; set; }
        public DbSet<CollectibleType> CollectibleTypes { get; set; }
    }
}