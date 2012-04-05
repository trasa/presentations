using System;
using System.Diagnostics;
using System.Reflection;
using Blackfin.Cms.Engine;
using Blackfin.Cms.Stubs;
using Common.Logging;
using NUnit.Framework;

namespace Blackfin.Cms.Test.Engine
{
    [TestFixture]
    public class AttributeCatalogFixture
    {
        static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        [Test]
        public void GetAttributes()
        {
            // we tagged RequestStub and LocationStub, lets see if they're found:
            AttributeCollection<DummyAttribute> col = AttributeCatalog.GetAttributes<DummyAttribute>();
            Assert.AreEqual(2, col.Count);
            foreach(AttributeCatalogEntry<DummyAttribute> entry in col)
            {
                Assert.IsNotNull(entry.AttributeTargetType);
                log.Debug(entry.AttributeTargetType.Name);
            }
        }

        [Test]
        public void AttributeCatalogEntryEquality_AreEqual()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(string));
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(string));
            // should not generate exceptions:
            left.GetHashCode();
            right.GetHashCode();
            Assert.AreEqual(left, right);
        }

        [Test]
        public void AttributeCatalogEntryEquality_AreNotEqual_Attributes()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(string));
            AttributeCatalogEntry<ConditionalAttribute> right = new AttributeCatalogEntry<ConditionalAttribute>(new ConditionalAttribute("foo"), typeof(string));
            // should not generate exceptions:
            left.GetHashCode();
            right.GetHashCode();
            Assert.AreNotEqual(left, right);
        }

        [Test]
        public void AttributeCatalogEntryEquality_AreNotEqual_Types()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(string));
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(int));
            // should not generate exceptions:
            left.GetHashCode();
            right.GetHashCode();
            Assert.AreNotEqual(left, right);
        }

        [Test]
        public void AttributeCatalogEntryEquality_AreNotEqual_NullAttribute()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(null, typeof(string));
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(int));
            // should not generate exceptions:
            left.GetHashCode();
            right.GetHashCode();
            Assert.AreNotEqual(left, right);
        }

        [Test]
        public void AttributeCatalogEntryEquality_AreNotEqual_NullTypes()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), null);
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(int));
            // should not generate exceptions:
            left.GetHashCode();
            right.GetHashCode();
            Assert.AreNotEqual(left, right);
        }
    }
}
