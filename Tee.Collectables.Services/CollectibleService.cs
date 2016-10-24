using System.Collections.Generic;
using Tee.Collectibles.Common.Entities;
using Tee.Collectibles.Common.Repository;
using Tee.Collectibles.Common.Services;

namespace Tee.Collectables.Services
{
    public class CollectibleService : ICollectibleService
    {
        private readonly IRepository<Collectible> _repository;

        public CollectibleService(IRepository<Collectible> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Collectible> GetAllCollectibles()
        {
            return this._repository.GetAll();
        }

        public Collectible GetCollectibleById(int id)
        {
            return this._repository.Get(id);
        }

        public void Delete(Collectible collectible)
        {
            this._repository.Delete(collectible);
        }

        public void Update(Collectible collectible)
        {
            this._repository.Update(collectible);
        }

        public int Add(Collectible collectible)
        {
            return this._repository.Insert(collectible);
        }
    }
}