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

        /// <summary>
        /// This method iterates over an enumeration and use for each item the <paramref name="castCallback"/> to return an enumeration of a different type.
        /// </summary>
        /// <typeparam name="TInput">The type parameter of the items in the input values enumeration.</typeparam>
        /// <typeparam name="TOutput">The type parameter of the items returned by this method.</typeparam>
        /// <param name="inputValues">An enumeration of items that should be casted.</param>
        /// <param name="castCallback">A callback that is called for each item in <paramref name="inputValues"/>. The input value is passed as a parameter to the callback. The callback returns a casted or converted value.</param>
        /// <returns>
        /// Returns an enumeration of <typeparamref name="TOutput"/>. The enumeration is empty if either <paramref name="inputValues"/> is empty or <c>null</c>, or <paramref name="castCallback"/> is <c>null</c>.
        /// </returns>
        public static IEnumerable<TOutput> Cast<TInput, TOutput>(this IEnumerable<TInput> inputValues, Converter<TInput, TOutput> castCallback)
        {
            if (inputValues == null || castCallback == null)
                yield break;

            foreach (TInput inputValue in inputValues)
                yield return castCallback(inputValue);
        }
    }
}
