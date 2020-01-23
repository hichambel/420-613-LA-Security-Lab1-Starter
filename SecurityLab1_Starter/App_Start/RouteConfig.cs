using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Blank",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { action = "Index|Contact|About" }
            );

            routes.MapRoute(
                name: "InventoryIndex",
                url: "Inventory/Index/{id}",
                defaults: new { controller = "Inventory", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GenError",
                url: "Home/GenError",
                defaults: new { controller = "Home", action = "GenError", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ServerError",
                url: "Error/ServerError",
                defaults: new { controller = "Error", action = "ServerError" }
            );

            routes.MapRoute(
               name: "Error",
               url: "{*url}",
               defaults: new { controller = "Error", action = "NotFound" }
               );


        }
    }
}
