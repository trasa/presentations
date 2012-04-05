using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using RobotArmy.Core.Model;

namespace RobotArmy.Test.Controllers.RobotControllerFixtures
{


    [TestFixture]
    public class When_Listing_Robots : RobotController_Context
    {
        [Test]
        public void Redirected_To_List_View()
        {
            // act
            ActionResult result = RobotController.List();

            // assert
            result
                .AssertViewRendered()           // should have gotten a view
                .ForView("")                    // assert view name return is default
                .WithViewData<IList<Robot>>();  // with the right sort of data in it

        }
    }
}
