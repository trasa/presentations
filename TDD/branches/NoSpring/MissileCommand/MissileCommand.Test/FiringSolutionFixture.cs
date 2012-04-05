using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MissileCommand.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace MissileCommand.Test
{
    [TestFixture]
    public class FiringSolutionFixture
    {
        [Test]
        public void divbyzero()
        {
            double x=-1, y=0;
            double value = x/y;
            Console.WriteLine(value);
        }


        [Test]
        public void Fire()
        {
            // setup
            MockRepository mocks = new MockRepository();
            IMissileLaunchingSystem system = mocks.CreateMock<IMissileLaunchingSystem>();
            IVectorProvider vectorProvider = mocks.CreateMock<IVectorProvider>();

            // code under test:
            FiringSolution fire  = new FiringSolution(new TargetingSystem(vectorProvider));
            using (mocks.Record())
            {
                // read from left to right, not inner to outer
                Expect.Call(system.SendLaunchOrders(fire)).Return("Test Successful");
            }

            // did it work?
            using(mocks.Playback())
            {
                string result = fire.Fire(system);
                Assert.AreEqual("Test Successful", result);
            }

        }

        /*
        [Test]
        public void CalculateSplines_PositiveVector_Simple()
        {
            MockRepository mocks = new MockRepository();

            ITargetingSystem targetingSystem = mocks.CreateMock<ITargetingSystem>();
            using (mocks.Record())
            {
                Expect.Call(targetingSystem.GeographicBias).Return(1.0);
            }
            using (mocks.Playback())
            {
                FiringSolution firstSol = new FiringSolution(targetingSystem, 1.0);
                FiringSolution result = firstSol.ReticulateSplines(1);
                Assert.That(result.Vector,Is.EqualTo(0.0));
            }
        } 
         
          
          
          
        [Test]
        public void VectorCantBeZero()
        {
            MockRepository mocks = new MockRepository();

            ITargetingSystem targetingSystem = mocks.CreateMock<ITargetingSystem>();
            using (mocks.Record())
            {
                // nothing to record - our mock won't get called
            }
            using (mocks.Playback())
            {
                FiringSolution firstSol = new FiringSolution(targetingSystem, 0);
                try
                {
                    firstSol.ReticulateSplines(1);
                    Assert.Fail("should have gotten an InvalidVectorException here");
                } 
                catch(InvalidVectorException)
                {
                    // success
                }
            }
        }
       
        
       
        [Test]
        public void CalculateSplines_NegativeVector_Simple()
        {
            MockRepository mocks = new MockRepository();

            ITargetingSystem targetingSystem = mocks.CreateMock<ITargetingSystem>();
            using (mocks.Record())
            {
                Expect.Call(targetingSystem.GeographicBias).Return(1.0);
            }
            using (mocks.Playback())
            {
                FiringSolution firstSol = new FiringSolution(targetingSystem, 1.0);
                FiringSolution result = firstSol.ReticulateSplines(-1);
                Assert.That(result.Vector, Is.EqualTo(0.0));
            }
        }
         
        [Test]
        public void CalculateSplines_NegativeVector_MoreComplicated()
        {
            MockRepository mocks = new MockRepository();

            ITargetingSystem targetingSystem = mocks.CreateMock<ITargetingSystem>();
            using (mocks.Record())
            {
                Expect.Call(targetingSystem.GeographicBias).Return(1.0);
            }
            using (mocks.Playback())
            {
                FiringSolution firstSol = new FiringSolution(targetingSystem, 1.0);
                FiringSolution result = firstSol.ReticulateSplines(-2);
                Assert.That(result.Vector, Is.EqualTo(-0.69314).Within(0.00001));
            }
        }
         */
    }
}
