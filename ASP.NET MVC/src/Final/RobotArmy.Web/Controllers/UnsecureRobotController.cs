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

        [Transaction]
        public ActionResult Edit(Robot robot)
        {
            robotRepository.Save(robot);
            return RedirectToAction<RobotController>(c => c.List());
        }
    }
}
