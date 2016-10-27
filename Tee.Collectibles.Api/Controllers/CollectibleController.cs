using System;
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

        public IHttpActionResult Get()
        {
            IEnumerable<Collectible> result;
            try
            {
                result = this._collectibleService.GetAllCollectibles().ToList();
            }
            catch (Exception)
            {
                return BadRequest("Can't retrieve collectibles");
            }

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            Collectible result;

            try
            {
                result = this._collectibleService.GetCollectibleById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(result);
        }

        public IHttpActionResult Post(Collectible data)
        {
            int result;

            try
            {
                result = this._collectibleService.Add(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        public IHttpActionResult Put(Collectible data)
        {
            try
            {
                this._collectibleService.Update(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var collectible = this._collectibleService.GetCollectibleById(id);
                this._collectibleService.Delete(collectible);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}