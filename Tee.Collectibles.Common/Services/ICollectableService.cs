using System.Collections.Generic;
using Tee.Collectibles.Common.Entities;

namespace Tee.Collectibles.Common.Services
{
    public interface ICollectibleService
    {
        IEnumerable<Collectible> GetAllCollectibles();

        Collectible GetCollectibleById(int id);

        int Add(Collectible collectible);

        void Update(Collectible collectible);

        void Delete(Collectible collectible);
    }
}