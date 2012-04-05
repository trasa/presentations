using System;
using System.Collections.Generic;
using Blackfin.SpringHelper;
using MissileCommand.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace MissileCommand.Test
{
    [TestFixture]
    public class TargetingSystemFixture
    {
        [Test]
        public void ComputeFiringSolution()
        {
            MockRepository mocks = new MockRepository();
            IVectorProvider vectorProvider = mocks.CreateMock<IVectorProvider>();
            Factory<IVectorProvider>.RegisterFake(vectorProvider);
            
            using (mocks.Record())
            {
                Expect.Call(vectorProvider.GetTargetingVectors()).Return(new List<double> { 1.0 });
            }
            
            using (mocks.Playback())
            {
                TargetingSystem system = new TargetingSystem();
                FiringSolution solution = system.ComputeFiringSolution();

                // how do you test this when it comes from the disk, and theres no telling how long it could run?
                Assert.That(solution.Vector, Is.EqualTo(0.0));
            }

            Factory<IVectorProvider>.ClearFakes();
        }
    }
}
