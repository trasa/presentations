using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArmy.Core.Helpers;
using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;

namespace RobotArmy.Web.Controllers
{
    public class UnsecureRobotController : SmartController 
    {
        private readonly IRepository<Robot> robotRepository;

        public UnsecureRobotController(IRepository<Robot> robotRepository)
        {
            this.robotRepository = robotRepository;
        }

        #region Presentation FAIL insurance
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit()
        {
            // because I tend to type in the wrong URL.
            return Redirect("~/Evil.htm");
        }
        #endregion


        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Edit(Robot robot)
        {
            robotRepository.Save(robot);
            return RedirectToAction<RobotController>(c => c.List());
        }
    }
}
