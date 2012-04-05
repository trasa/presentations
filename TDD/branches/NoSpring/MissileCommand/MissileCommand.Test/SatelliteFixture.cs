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
        public void ComputeVelocity_ZeroAltitude()
        {
            Satellite s = new Satellite();
            s.Altitude = 0;
            Assert.That(s.OrbitalVelocity, Is.EqualTo(7.909).Within(0.001));
        }


        [Test]
        public void ComputeVelocity_GeosynchronousOrbit()
        {
            Satellite s = new Satellite();
            s.Altitude = 35780; // numbers from wikipedia
            Assert.That(s.OrbitalVelocity, Is.EqualTo(3.07).Within(0.01));
        }


        [Test]
        public void NegativeAltitudeNotAllowed()
        {
            Satellite s = new Satellite();
            try
            {
                s.Altitude = -1;
                Assert.Fail("Altitude can't be negative");
            } catch(ArgumentOutOfRangeException)
            {
                // success
            }
        }
    }
}
