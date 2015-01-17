using DataTable.Demos.Site.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataTable.Demos.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DataTables", action = "Index", id = UrlParameter.Optional }
            );
            //);.RouteHandler = new SessionableStateRouteHandler(); // Config to access session from inside a WebApi method

        }
    }

  
}