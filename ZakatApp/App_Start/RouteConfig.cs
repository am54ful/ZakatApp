using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZakatApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //, id = UrlParameter.Optional
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index"},
                new { httpMethod = new HttpMethodConstraint("GET") }
            );
            routes.MapRoute(
                name: "user.store",
                url: "user/store",
                defaults: new { controller = "User", action = "Store"},
                new { httpMethod = new HttpMethodConstraint("POST") }
            );
        }
    }
}
