using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAuto.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Blog",
             url: "{controller}/page{pageindexa}",
             defaults: new { controller = "Blog", action = "Index", pageindexa = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Article",
             url: "{controller}/title_{pageindexa}",
             defaults: new { controller = "Blog", action = "Show", pageindexa = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Movie",
             url: "{controller}/page{pageindexa}",
             defaults: new { controller = "Movie", action = "Index", pageindexa = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Play",
             url: "{controller}/play_{pageindexa}",
             defaults: new { controller = "Movie", action = "Play", pageindexa = UrlParameter.Optional }
            );

        }
    }
}
