using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace estoqueApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( // prmeira pagina do site
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account   ", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
