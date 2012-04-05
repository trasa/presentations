using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotArmy.Core.Helpers;
using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;
using RobotArmy.Core.Services;

namespace RobotArmy.Web.Controllers
{
    public class ResetController : SmartController
    {
        private readonly IResetService resetService;

        public ResetController(IResetService resetService)
        {
            this.resetService = resetService;
        }

        [Transaction]
        public ActionResult ClearPsycho()
        {
            resetService.ClearPsychoRobots();
            return RedirectToAction<RobotController>(c => c.List());
        }
    }
}
