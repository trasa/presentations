using System;
using System.Collections.Generic;
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
            
            using (mocks.Record())
            {
                List<double> resultToReturn = new List<double>();
                resultToReturn.Add(1.0);
                Expect.Call(vectorProvider.GetTargetingVectors()).Return(resultToReturn);
            }
            
            using (mocks.Playback())
            {
                TargetingSystem system = new TargetingSystem(vectorProvider);
                FiringSolution solution = system.ComputeFiringSolution();

                // how do you test this when it comes from the disk, and theres no telling how long it could run?
                Assert.That(solution.Vector, Is.EqualTo(0.0));
            }
        }
    }
}
