using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Blackfin.Cms.Engine.Extensions
{
    /// <summary>
    /// Extensions for Lists
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Converts a List[T] to a Collection[T]
        /// </summary>
        /// <param name="list">The list to convert.</param>
        /// <returns>Collection of the List[T]</returns>
        public static Collection<T> ToCollection<T>(this IList<T> list)
        {
            return new Collection<T>(list);
        }

        /// <summary>
        /// Converts all the input type to the output type.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public static List<TOutput> ConvertAll<TInput, TOutput>(this IList<TInput> list, Converter<TInput, TOutput> converter)
        {
            return new List<TInput>(list).ConvertAll(converter);
        }

        /// <summary>
        /// Adds all the elements into this list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="items">The items to add.  everything in this MUST be convertable to T, or an exception will occur.</param>
        public static void AddAll<T>(this IList<T> list, IEnumerable items)
        {
            foreach(var item in items.Cast<T>())
            {
                list.Add(item);
            }
        }

    }
}
