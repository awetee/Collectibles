namespace Tee.Collectibles.Api.IServices
{
    using System.Collections.Generic;
    using Tee.Collectibles.Common.Entities;

    public interface ICollectibleService
    {
        IEnumerable<Collectible> GetAll();

        Collectible Get(int id);

        int Add(Collectible collectible);

        void Update(Collectible collectible);

        void Delete(Collectible collectible);
    }
}