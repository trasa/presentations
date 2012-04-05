using System;
using System.Reflection;
using Common.Logging;


namespace Blackfin.Cms.Engine
{
    
    /// <summary>
    /// Searches through the current application domain, looking for types and
    /// information denoted by a given <see cref="Attribute"/>.
    /// </summary>
    public static class AttributeCatalog 
    {
        static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Gets the instances of the target Attribute from the current AppDomain.
        /// </summary>
        /// <returns>a Collection of Attribute instances matching the target</returns>
        /// <typeparam name="T">The Attribute type we seek</typeparam>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate"), 
         System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "This is not a property, returns a different collection each time")]
        public static AttributeCollection<T> GetAttributes<T>() where T : Attribute
        {
            try
            {
                AttributeCollection<T> attributes = new AttributeCollection<T>();
                foreach(Type t in TypeCatalog.GetTypesWithAttribute<T>())
                {
                    foreach (T attr in t.GetCustomAttributes(typeof(T), false))
                    {
                        attributes.Add(new AttributeCatalogEntry<T>(attr, t));
                    }
                }
                return attributes;
            } 
            catch (ReflectionTypeLoadException e)
            {
                // for some reason we can't get the set of attributes out - log information about the
                // problem and rethrow
                string errMsg = "Received a TypeLoad exception while trying to find all Attributes of type " + typeof(T).Name + ", loader exception follows: " + Environment.NewLine;
                foreach(Exception le in e.LoaderExceptions)
                {
                    errMsg += le.Message + Environment.NewLine;
                }
                log.Error(errMsg);
                throw;
            }
        }
    }
}
