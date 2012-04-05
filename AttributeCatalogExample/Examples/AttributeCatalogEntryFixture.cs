using Blackfin.Cms.Engine;
using Blackfin.Cms.Stubs;
using NUnit.Framework;


namespace Blackfin.Cms.Test.Engine
{
    
    [TestFixture]
    public class AttributeCatalogEntryFixture
    {
        [Test]
        public void InstanceEquality()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            Assert.IsTrue(left.Equals(right));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Test]
        public void InstanceInequality()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(DummyAttribute));
            Assert.IsFalse(left.Equals(right));
        }

        [Test]
        public void OperatorEquality()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);
        }

        [Test]
        public void OperatorInEquality()
        {
            AttributeCatalogEntry<DummyAttribute> left = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), GetType());
            AttributeCatalogEntry<DummyAttribute> right = new AttributeCatalogEntry<DummyAttribute>(new DummyAttribute(), typeof(DummyAttribute));
            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);
        }
    }
}
