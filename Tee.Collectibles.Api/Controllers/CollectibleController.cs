using System.Linq;
using System.Web.Http.Cors;
using Tee.Collectibles.Common.Entities;
using Tee.Collectibles.Common.Services;

namespace Tee.Collectibles.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    //[Authorize]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CollectibleController : ApiController
    {
        private readonly ICollectibleService _collectibleService;

        public CollectibleController(ICollectibleService collectibleService)
        {
            _collectibleService = collectibleService;
        }

        public IEnumerable<Collectible> Get()
        {
            var result = this._collectibleService.GetAllCollectibles().ToList();
            return result;
        }

        public Collectible Get(int id)
        {
            var result = this._collectibleService.GetCollectibleById(id);
            return result;
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
            var collectible = this._collectibleService.GetCollectibleById(id);
            this._collectibleService.Delete(collectible);
        }
    }
}