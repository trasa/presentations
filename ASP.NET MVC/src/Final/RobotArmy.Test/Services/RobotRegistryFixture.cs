using NUnit.Framework;
using RobotArmy.Core.Services;
using StructureMap;

namespace RobotArmy.Test.Services
{
    [TestFixture]
    public class RobotRegistryFixture
    {
        [SetUp]
        public void SetUp()
        {
            ObjectFactory.Initialize(init => init.AddRegistry<RobotRegistry>());
        }

        [TearDown]
        public void TearDown()
        {
            ObjectFactory.ResetDefaults();
        }

        [Test]
        public void Validate()
        {
            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}
