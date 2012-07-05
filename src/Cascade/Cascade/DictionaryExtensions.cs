using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade
{
    /// <summary>
    /// The static <i>DictionaryExtensions</i> class contains extension methods which are usable on <see cref="IDictionary&lt;TKey, TValue>" /> types.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// The methods returns the value of an dictionary by using its key.
        /// </summary>
        /// <typeparam name="TKey">Type parameter of the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">Type parameter of the value of the dictionary.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="key">The key to get the value out of the dictionary.</param>
        /// <returns>
        /// Returns the actual dictionary value if the <paramref name="key"/> was found in the dictionary, in any other case the default value of <typeparamref name="TValue"/> is returned.
        /// </returns>
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> target, TKey key)
        {
            
            if (target == null || !target.ContainsKey(key))
                return default(TValue);

            return target[key];
        }

        /// <summary>
        /// The method returns the value of an dictionary by using its key, or if the key is not yet part of the dictionary, using a callback to return and store a value inside the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type parameter of the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">Type parameter of the value of the dictionary.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="key">The key to get the value out of the dictionary. The key is also used to store a new value in the dictionary, when the <paramref name="valueNeededCallback">callback</paramref>
        /// method is used to store a new value in the dictionary.</param>
        /// <param name="valueNeededCallback">A callback that is used to store a new value in the dictionary. The callback is used when the dictionary does not contain an entry with the given
        /// key.</param>
        /// <returns>
        /// The method will return the entry value if an entry with the given key <paramref name="key"/> was found in the dictionary. If <paramref name="valueNeededCallback"/> is not <c>null</c>, the
        /// return value of this callback is returned by this method.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The method uses the <paramref name="valueNeededCallback"/> if specified and if the <paramref name="key"/> has no corresponding entry in the dictionary. In this case the result of the callback
        /// is added to the dictionary using the given key. After that the result value of the callback is returned by this method.
        /// </para>
        /// <para>
        /// However if the entry in the dictionary exists, but the value is equal to the default value of <typeparamref name="TValue"/>, it will be returned without calling <paramref name="valueNeededCallback"/>.
        /// </para>
        /// </remarks>
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> target, TKey key, Func<TValue> valueNeededCallback)
        {
            if (target != null)
                if (target.ContainsKey(key))
                    return target[key];
                else
                    if (valueNeededCallback != null)
                    {
                        TValue value = valueNeededCallback();
                        target.Add(key, value);
                        return value;
                    }

            return default(TValue);
        }
    }
}
