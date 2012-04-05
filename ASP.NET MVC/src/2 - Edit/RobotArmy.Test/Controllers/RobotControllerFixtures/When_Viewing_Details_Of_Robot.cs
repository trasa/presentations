using MvcContrib.TestHelper;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using RobotArmy.Core.Model;
using RobotArmy.Web.Controllers;

namespace RobotArmy.Test.Controllers.RobotControllerFixtures
{
    [TestFixture]
    public class When_Viewing_Details_Of_Robot : RobotController_Context
    {
        [Test]
        public void Given_Bad_Robot_Id_Redirect_To_List()
        {
            // arrange
            RobotRepository.Expect(call => call.Get(42)).Return(null);

            // act
            var actionResult = RobotController.Details(42);

            // assert
            actionResult
                .AssertActionRedirect() // an ActionDirect, not a view!
                .ToAction<RobotController>(c => c.List());
        }




        [Test]
        public void Given_Good_Robot_Id_Redirected_To_Detail_View()
        {
            // arrange
            var robotResult = new Robot();
            RobotRepository.Expect(call => call.Get(42)).Return(robotResult);

            // act
            var actionResult = RobotController.Details(42);

            // assert
            var viewData = actionResult
                .AssertViewRendered()
                .ForView("")
                .WithViewData<Robot>();
            Assert.That(viewData, Is.SameAs(robotResult));
        }
    }
}
