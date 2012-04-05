using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blackfin.Cms.Engine.Extensions;

namespace Blackfin.Cms.Engine
{
    /// <summary>
    /// A Collection of AttributeCatalogEntries.
    /// </summary>
    /// <typeparam name="T">Some sort of Attribute</typeparam>
    public class AttributeCollection<T> : Collection<AttributeCatalogEntry<T>> where T : Attribute
    {
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <returns>List of Attributes</returns>
        public IEnumerable<T> GetAttributes()
        {
            return this.ConvertAll(entry => entry.Attribute);
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns>list of types</returns>
        public IEnumerable<Type> GetTypes()
        {
            return this.ConvertAll(entry => entry.AttributeTargetType);
        }
    }
}
