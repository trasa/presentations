using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobotArmy.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to The Seven Nation Robot Army!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
