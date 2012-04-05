using System;
using System.Collections.Generic;
using System.Reflection;
using Blackfin.Cms.Engine;
using Common.Logging;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Blackfin.Cms.Test.Engine
{
    [TestFixture]
    public class TypeCatalogFixture
    {
        [Test]
        public void FindByFilter()
        {
            IList<Type> result = TypeCatalog.GetTypes(SearchForTypeCatalogFixture_NoInheritance);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(typeof(TypeCatalogFixture)));
        }

        [Test]
        public void FindByFilter_TypeCatalogProvided_Type()
        {
            IList<Type> result = TypeCatalog.GetTypes(TypeCatalog.FilterTypesByInheritedType<TypeCatalogFixture>);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindByFilter_WithChildren()
        {
            IList<Type> result = TypeCatalog.GetTypes(SearchForTypeCatalogFixture_WithChildren);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetByType()
        {
            IList<Type> result = TypeCatalog.GetTypesInheritedFrom<TypeCatalogFixture>();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        
        


        private static bool SearchForTypeCatalogFixture_NoInheritance(Type m, object filterCriteria)
        {
            return m.Equals(typeof(TypeCatalogFixture));
        }

        private static bool SearchForTypeCatalogFixture_WithChildren(Type m, object filterCriteria)
        {
            return m.IsAssignableFrom(typeof(TypeCatalogFixture));
        }
    }

    public class AnotherTypeCatalogFixture : TypeCatalogFixture
    {
        // just a test
    }
}
