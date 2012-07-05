using System;
using System.Collections;
using System.Collections.Generic;

namespace Cascade
{
    /// <summary>
    /// The static <i>EnumerableExtensions</i> class contains extension methods which are used for types implementing the <see cref="System.Collections.IEnumerable"/> interface.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// This method iterates over an enumeration and using a callback for each item in the enumeration.
        /// </summary>
        /// <param name="targetValues">An enumeration to iterate over.</param>
        /// <param name="callback">A callback which is called for each item which is returned when iterating over <paramref name="targetValues"/>.</param>
        public static void ForEach(this IEnumerable targetValues, Action<object> callback)
        {
            if (targetValues != null && callback != null)
                foreach (object targetValue in targetValues)
                    callback(targetValue);
        }

        /// <summary>
        /// This method itererates over an enumeration and using a callback for each item in the enumeration.
        /// </summary>
        /// <typeparam name="T">The type parameter of the items in the enumeration.</typeparam>
        /// <param name="targetValues">An enumeration to iterate over.</param>
        /// <param name="callback">A callback which is called for each item which is returned when iterating over <paramref name="targetValues"/>.</param>
        public static void ForEach<T>(this IEnumerable<T> targetValues, Action<T> callback)
        {
            if (targetValues != null && callback != null)
                foreach (T targetValue in targetValues)
                    callback(targetValue);
        }
    }
}
