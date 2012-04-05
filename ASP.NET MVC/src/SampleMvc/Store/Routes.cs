using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store
{
    public static class Routes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapAreaRoute(
                "Store",
                "Store_Default",
                "Store/{controller}/{action}/{id}",
                new { controller = "Products", action = "List", id = "" },
                new string[] { "Store.Controllers" }
            );
        }

    }
}
