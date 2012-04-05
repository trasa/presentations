using NUnit.Framework;
using Rhino.Mocks;
using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;
using RobotArmy.Web.Controllers;

namespace RobotArmy.Test.Controllers.RobotControllerFixtures
{
    public class RobotController_Context
    {
        [SetUp]
        public virtual void SetUp()
        {
            RobotRepository = MockRepository.GenerateStub<IRepository<Robot>>();
            Assert.Fail("HEY!  YOU FORGOT TO UNCOMMENT THE ROBOT CONTROLLER!");
//            RobotController = new RobotController(RobotRepository);
        }

        protected RobotController RobotController { get; private set; }
        protected IRepository<Robot> RobotRepository { get; private set; }
    }
}
