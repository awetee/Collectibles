namespace Tee.Collectibles.DAL
{
    using System.Data.Entity;
    using Tee.Collectibles.DAL.Entities;

    public class CollectibleContext : DbContext
    {
        public CollectibleContext() : base("CollectibleContext")
        {
        }

        public DbSet<Collectible> Collectibles { get; set; }
    }
}