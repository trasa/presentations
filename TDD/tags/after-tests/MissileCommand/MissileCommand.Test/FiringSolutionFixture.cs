﻿using System;
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
                FiringSolution firstSol = new FiringSolution(targetingSystem);
                try
                {
                    firstSol.Vector = 0;
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
                FiringSolution firstSol = new FiringSolution(targetingSystem);
                firstSol.Vector = 1;
                FiringSolution result = firstSol.ReticulateSplines(1);
                Assert.That(result.Vector,Is.EqualTo(0.0));
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
                FiringSolution firstSol = new FiringSolution(targetingSystem);
                firstSol.Vector = 1;
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
                FiringSolution firstSol = new FiringSolution(targetingSystem);
                firstSol.Vector = 1;
                FiringSolution result = firstSol.ReticulateSplines(-2);
                Assert.That(result.Vector, Is.EqualTo(-0.69314).Within(0.00001));
            }
        }
    }
}
