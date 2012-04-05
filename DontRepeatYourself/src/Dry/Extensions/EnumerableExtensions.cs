using System.Collections.Generic;
using System.Linq;

namespace Dry.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>
        /// 	<c>true</c> if the collection is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }

    }
}
