using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Tee.Collectables.Services;
using Tee.Collectibles.Api.Controllers;
using Tee.Collectibles.Common.Entities;
using Tee.Collectibles.DAL;
using Tee.Collectibles.DAL.Repository;

namespace Tee.Collectibles.Api.IoC
{
    public class CompositionRoot : IHttpControllerActivator
    {
        public CompositionRoot()
        {
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var collectibleContext = new CollectibleContext();
            var repository = new Repository<Collectible>(collectibleContext);
            var collectibleService = new CollectibleService(repository);

            if (controllerType == typeof(CollectibleController))
            {
                return new CollectibleController(collectibleService);
            }

            throw new ArgumentException("Unexpected type!", nameof(controllerType));
        }
    }
}