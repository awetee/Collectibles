namespace Tee.Collectibles.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using Tee.Collectibles.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Tee.Collectibles.DAL.CollectibleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CollectibleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            context.CollectibleTypes.AddOrUpdate(
              p => p.Name,
              new CollectibleType { Name = "Technology" },
              new CollectibleType { Name = "Brands" },
              new CollectibleType { Name = "Books" },
              new CollectibleType { Name = "Architecture" },
              new CollectibleType { Name = "Art" },
              new CollectibleType { Name = "Card" },
              new CollectibleType { Name = "Aphemera" },
              new CollectibleType { Name = "Clothing" },
              new CollectibleType { Name = "Currency" },
              new CollectibleType { Name = "Sport" },
              new CollectibleType { Name = "Music" }
            );
        }
    }
}