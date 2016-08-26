using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HpAer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("GetProvinciasByPaisId",
                           "Direcciones/GetProvinciasByPaisId/",
                           new { controller = "DireccionController", action = "GetProvinciasByPaisId" },
                           new[] { "HpAer.Controllers" }
            );
            routes.MapRoute("GetLocalidadesByProvinciaId",
               "Direcciones/GetLocalidadesByProvinciaId/",
               new { controller = "DireccionController", action = "GetLocalidadesByProvinciaId" },
               new[] { "HpAer.Controllers" }
            );
            routes.MapRoute("GetBarriosByLocalidadId",
            "Direcciones/GetBarriosByLocalidadId/",
            new { controller = "DireccionController", action = "GetBarriosByLocalidadId" },
            new[] { "HpAer.Controllers" }
            );
        }
    }
}
