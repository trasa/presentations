using System.Security.Principal;
using System.Web.Mvc;
using RobotArmy.Core.Helpers;

namespace RobotArmy.Web.Controllers
{
    [Authorize]
    public class AdminController : SmartController
    {
        private readonly IPrincipal user;

        public AdminController(IPrincipal user)
        {
            this.user = user;
        }

        /// <summary>
        /// You must be authorized to get to this view.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// You must be both authorized, and in the admins role,
        /// to get here.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admins")]
        [LogAction]
        public ActionResult AdminsOnly()
        {
            return View((object)user.Identity.Name);
        }
    }
}
