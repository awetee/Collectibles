using Tee.Collectibles.Common.Entities;

namespace Tee.Collectibles.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Tee.Collectibles.Api.IServices;

    [Authorize]
    public class CollectibleController : ApiController
    {
        private readonly ICollectibleService _collectibleService;

        public CollectibleController(ICollectibleService collectibleService)
        {
            _collectibleService = collectibleService;
        }

        public IEnumerable<Collectible> Get()
        {
            return this._collectibleService.GetAll();
        }

        [Route("GetById/{id}")]
        public Collectible Get(int id)
        {
            return this._collectibleService.Get(id);
        }

        public int Post(Collectible data)
        {
            return this._collectibleService.Add(data);
        }

        public void Put(Collectible data)
        {
            this._collectibleService.Update(data);
        }

        public void Delete(int id)
        {
            var collectible = this._collectibleService.Get(id);
            this._collectibleService.Delete(collectible);
        }
    }
}