using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pos.Core.Dto.Seguridad;
using Pos.Infraestructure.Atributos;

namespace Pos.Infraestructure.Services
{
    public class RouteService
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public RouteService(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IEnumerable<MenuDto> GetllMenus()
        {
            List<MenuDto> routes = [];

            //var descriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items
            //    .Where(atr => atr.AttributeRouteInfo is not null)
            //    .Select(descriptor => descriptor)
            //    .ToList();

            //if (descriptors is null) return routes;

            //foreach (var descriptor in descriptors)
            //{
            //    var attribute = descriptor.EndpointMetadata.OfType<MenuAttribute>().FirstOrDefault();
            //    if (attribute is not null)
            //    {
            //        if (!routes.Any(route => (route.Url ?? string.Empty).ToLower().Equals(attribute.Url.ToLower())))
            //            routes.Add(new MenuDto
            //            {
            //                Padre = attribute.Padre,
            //                Url = attribute.Url,
            //                Titulo = attribute.Titulo,
            //            });
            //    }

            //}

            return routes;

        }
    }
}
