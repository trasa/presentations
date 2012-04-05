using NUnit.Framework;
using Rhino.Mocks;
using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;
using RobotArmy.Core.Services;
using RobotArmy.Web.Controllers;

namespace RobotArmy.Test.Controllers.RobotControllerFixtures
{
    public class RobotController_Context
    {
        [SetUp]
        public virtual void SetUp()
        {
            RobotRepository = MockRepository.GenerateStub<IRepository<Robot>>();
            RobotController = new RobotController(RobotRepository);
        }

        protected RobotController RobotController { get; private set; }
        protected IRepository<Robot> RobotRepository { get; private set; }
    }
}
