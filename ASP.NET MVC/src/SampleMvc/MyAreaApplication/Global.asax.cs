using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAreaApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // NOTE: Area Route Registration
            Account.Routes.RegisterRoutes(routes);
            Store.Routes.RegisterRoutes(routes);

            routes.MapAreaRoute(
                "Main",                                                 // Route name
                "Main_Default",
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }, // Parameter defaults
                new string[] { "MyAreaApplication.Controllers" }
            );

        }


        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}