using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImageOptimizationWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "WebP",
                url: "WebP",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Compressive",
                url: "Compressive",
                defaults: new { controller = "Home", action = "Compressive", id = UrlParameter.Optional }
            );

            // frikkin typo in the tinyurl shortcode.. ugh..
            routes.MapRoute(
                name: "copmressive",
                url: "copmressive",
                defaults: new { controller = "Home", action = "Compressive", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}