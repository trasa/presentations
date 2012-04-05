using System;
using System.Linq;
using Blackfin.Cms.Engine;
using Blackfin.Cms.Stubs;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Blackfin.Cms.Test.Engine
{
    [TestFixture]
    public class AttributeCollectionFixture
    {
        [Test]
        public void GetAttributes()
        {
            // we tagged RequestStub and LocationStub, lets see if they're found:
            AttributeCollection<DummyAttribute> col = AttributeCatalog.GetAttributes<DummyAttribute>();
            Assert.AreEqual(2, col.Count);
            Assert.That(col.GetAttributes().Count(), Is.EqualTo(2));
            
        }

        [Test]
        public void GetAttributeTypes()
        {
            // we tagged RequestStub and LocationStub, lets see if they're found:
            AttributeCollection<DummyAttribute> col = AttributeCatalog.GetAttributes<DummyAttribute>();
            Assert.AreEqual(2, col.Count);
            Assert.That(col.GetTypes().Count(), Is.EqualTo(2));
            foreach(Type t in col.GetTypes())
            {
                Assert.IsTrue(t == typeof(RequestStub) || t == typeof(LocationStub));
            }
        }


    }
}
