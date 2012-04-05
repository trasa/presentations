using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Account
{
    public static class Routes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapAreaRoute(
                "Account",
                "Account_Default",
                "Profile/{action}/{id}",
                new { controller = "Account", action = "Index", id = "" },
                new string[] { "Account.Controllers" }
            );
        }

    }
}
