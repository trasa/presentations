using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Logging;


namespace Blackfin.Cms.Engine
{
    /// <summary>
    /// Searches through the current application domain, looking for types.
    /// </summary>
    public class TypeCatalog
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Gets all the types inherited (including) this type.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>List of Types</returns>
        public static IList<Type> GetTypesInheritedFrom<T>()
        {
            return GetTypes(FilterTypesByInheritedType<T>);
        }

        /// <summary>
        /// Gets the types with this attribute.
        /// </summary>
        /// <typeparam name="T">Attribute</typeparam>
        /// <returns>List of Types</returns>
        public static IList<Type> GetTypesWithAttribute<T>()
        {
            return GetTypes(FilterTypesByAttribute<T>);
        }

        /// <summary>
        /// Gets the instances of the target Attribute from the current AppDomain.
        /// </summary>
        /// <returns>a Collection of Attribute instances matching the target</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is not a property, returns a different collection each time"),
         System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static IList<Type> GetTypes(TypeFilter filter) 
        {
            try
            {
                List<Type> types = new List<Type>();
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    GetTypesInAssembly(asm, types, filter);
                }
                return types;
            }
            catch (ReflectionTypeLoadException e)
            {
                string errMsg = "Received a TypeLoad exception while trying to find all Types matching a filter, loader exception follows: " + Environment.NewLine;
                foreach (Exception le in e.LoaderExceptions)
                {
                    errMsg += le.Message + Environment.NewLine;
                }
                log.Error(errMsg);
                throw;
            }
        }

        /// <summary>
        /// For use with TypeCatalog, as a TypeFilter - include only the types
        /// that inherit from the provided type.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="filterCriteria">The filter criteria.</param>
        /// <returns></returns>
        public static bool FilterTypesByInheritedType<TType>(Type m, object filterCriteria)
        {
            return m.IsAssignableFrom(typeof(TType));
        }

        /// <summary>
        /// A TypeFilter that includes only the types that have an instance of the given attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="m">The m.</param>
        /// <param name="filterCriteria">The filter criteria.</param>
        /// <returns></returns>
        public static bool FilterTypesByAttribute<TAttribute>(Type m, object filterCriteria)
        {
            return m.GetCustomAttributes(typeof(TAttribute), false).Length > 0;
        }


        /// <summary>
        /// Get the types that match these criteria in this assembly.
        /// </summary>
        /// <param name="asm">The assembly to search.</param>
        /// <param name="types">The types.</param>
        /// <param name="filter">The filter.</param>
        private static void GetTypesInAssembly(Assembly asm, List<Type> types, TypeFilter filter) 
        {
            foreach (Module mod in asm.GetModules(false))
            {
                GetTypesInModule(mod, types, filter);
            }
        }

        /// <summary>
        /// Gets the instances of the target attribute from this module.
        /// </summary>
        /// <param name="mod">The module to search.</param>
        /// <param name="types">The types.</param>
        /// <param name="filter">The filter.</param>
        private static void GetTypesInModule(Module mod, List<Type> types, TypeFilter filter) 
        {
            types.AddRange(mod.FindTypes(filter, null));
        }
    }
}
