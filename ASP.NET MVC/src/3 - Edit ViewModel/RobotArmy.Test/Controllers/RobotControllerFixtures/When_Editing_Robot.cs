using MvcContrib.TestHelper;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using RobotArmy.Core.Model;
using RobotArmy.Web.Controllers;

namespace RobotArmy.Test.Controllers.RobotControllerFixtures
{
    [TestFixture]
    public class When_Editing_Robot : RobotController_Context
    {
        [Test]
        public void When_Robot_Doesnt_Exist_Redirect_To_List()
        {
            // arrange
            RobotRepository.Expect(call => call.Get(42)).Return(null);

            // act
            var actionResult = RobotController.Edit(42);

            // assert
            actionResult
                .AssertActionRedirect()
                .ToAction<RobotController>(c => c.List());
        }

        [Test]
        public void When_Robot_Does_Exist_View_Edit_Form()
        {
            // arrange
            var retrievedRobot = new Robot();
            RobotRepository.Expect(call => call.Get(42)).Return(retrievedRobot);

            // act
            var actionResult = RobotController.Edit(42);

            // assert
            var viewModel = actionResult
                .AssertViewRendered()
                .WithViewData<Robot>();
            Assert.That(viewModel, Is.SameAs(retrievedRobot));
        }
    }
}
