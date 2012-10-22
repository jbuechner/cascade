using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade
{
    /// <summary>
    /// The static <i>DictionaryExtensions</i> class contains extension methods which usable on <see cref="IDictionary{TKey, TValue}" /> types.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// The method returns the value of an entry in the dictionary by using its key or its default value if the entry is not present in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type parameter of the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">Type parameter of the value of the dictionary.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="key">The key of the entry in the dictionary.</param>
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
        /// The method returns the value of an entry inside a dictionary using a key. If no entry exists, a new entry with the given key will be added to the dictionary and returned.
        /// </summary>
        /// <typeparam name="TKey">Type parameter of the key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">Type parameter of the value type of the dictionary.</typeparam>
        /// <param name="target">Target object instance for this extension.</param>
        /// <param name="key">The key of the entry in the dictionary.</param>
        /// <param name="newEntryValue">The value added to the dictionary and returned if no entry with the key exists.</param>
        /// <returns>
        /// Returns the actual dictionary entry value if an entry with the key exists. In any other case, a new entry will be added to the dictionary, using <paramref name="newEntryValue"/> as entry value. The value is then returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the dictionary itself is <c>null</c> the default value of <typeparamref name="TValue"/> will be returned.
        /// </para>
        /// <para>
        /// If no entry with the key exists in the dictionary, a new entry with the key will be added to the dictionary, even if <paramref name="newEntryValue"/> is the default value of
        /// <typeparamref name="TValue"/>.
        /// </para>
        /// </remarks>
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> target, TKey key, TValue newEntryValue)
        {
            if (target != null)
                if (target.ContainsKey(key))
                    return target[key];
                else
                {
                    target.Add(key, newEntryValue);
                    return newEntryValue;
                }

            return default(TValue);
        }

        /// <summary>
        /// The method returns the value of an entry inside the dictionary using a key, or if no entry with the given key is present inside the dictionary, using a callback to return and store a value inside the dictionary.
        /// </summary>
        /// <typeparam name="TKey">Type parameter of the key of the dictionary.</typeparam>
        /// <typeparam name="TValue">Type parameter of the value of the dictionary.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="key">The key of the entry in the dictionary to return the value. The key is also used to store a new value in the dictionary, when the <paramref name="valueNeededCallback">callback</paramref>
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
