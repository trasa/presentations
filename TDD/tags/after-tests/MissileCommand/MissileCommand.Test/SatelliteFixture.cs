using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MissileCommand.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace MissileCommand.Test
{
    [TestFixture]
    public class SatelliteFixture
    {
        [Test]
        public void ComputeVelocity()
        {
            Satellite s = new Satellite();
            s.Altitude = 0;
            // solved this one on paper:
            Assert.That(s.OrbitalVelocity, Is.EqualTo(7.909963659).Within(0.0000000001));
        }
    }
}
