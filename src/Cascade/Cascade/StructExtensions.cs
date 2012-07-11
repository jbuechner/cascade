using System;
using System.Globalization;

namespace Cascade
{
    /// <summary>
    /// The static <i>StructExtensions</i> class contains extension methods which are used for structures.
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        /// Array of all integral types which are supported by the HasFlag extension and are usable as underlaying types for enums. Types with even index in the array are unsigned
        /// value types, types with uneven index are signed value types.
        /// </summary>
        static readonly Type[] IntegralTypes = new[] { typeof(Byte), typeof(SByte), typeof(UInt16), typeof(Int16), typeof(UInt32), typeof(Int32), typeof(UInt64), typeof(Int64) };

        // Analysis suppression, because callback is a nested generic, which cannot be avoid for this extension.
        /// <summary>
        /// This method performs an action if the nullable structure value is not <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type parameter for the nullable type.</typeparam>
        /// <param name="target">The target value.</param>
        /// <param name="callback">A callback which is called when <paramref name="target"/> is not <c>null</c>.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static void IfNotNull<T>(this Nullable<T> target, Action<Nullable<T>> callback)
            where T : struct
        {
            if (target != null && callback != null)
                callback(target);
        }

        // Analysis suppression, because callback is a nested generic, which cannot be avoid for this extension.
        /// <summary>
        /// This method performs an action if the nullable structure value is not <c>null</c> and returns the result value of that action.
        /// </summary>
        /// <typeparam name="TTarget">The type parameter for the nullable type.</typeparam>
        /// <typeparam name="TResult">The type parameter of the result of the callback.</typeparam>
        /// <param name="target">The target value.</param>
        /// <param name="callback">A callback which is used when <paramref name="target"/> is not <c>null</c>.</param>
        /// <returns>
        /// Returns either <c>null</c> if the <paramref name="callback"/> is <c>null</c>, the <paramref name="target"/> is <c>null</c>, or the result value of <paramref name="callback"/>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static TResult IfNotNull<TTarget, TResult>(this Nullable<TTarget> target, Func<Nullable<TTarget>, TResult> callback)
            where TTarget : struct
        {
            if (target != null && callback != null)
                return callback(target);

            return default(TResult);
        }

        /// <summary>
        /// This method performs an action if the nullable structure value is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type parameter for the nullable type.</typeparam>
        /// <param name="target">The target value.</param>
        /// <param name="callback">A callback which is called when <paramref name="target"/> is <c>null</c>.</param>
        public static void IfNull<T>(this Nullable<T> target, Action callback)
            where T : struct
        {
            if (target == null && callback != null)
                callback();
        }

        /// <summary>
        /// This method performs an action if the nullable structure value is <c>null</c> and returns the result value of that action.
        /// </summary>
        /// <typeparam name="TTarget">The type parameter for the nullable type.</typeparam>
        /// <typeparam name="TResult">The type parameter of the result of the callback.</typeparam>
        /// <param name="target">The target value.</param>
        /// <param name="callback">A callback which is used when <paramref name="target"/> is <c>null</c>.</param>
        /// <returns>
        /// Returns either <c>null</c> if the <paramref name="callback"/> is <c>null</c>, the <paramref name="target"/> is not <c>null</c>, or the result value of <paramref name="callback"/>.
        /// </returns>
        public static TResult IfNull<TTarget, TResult>(this Nullable<TTarget> target, Func<TResult> callback)
            where TTarget : struct
        {
            if (callback != null && target == null)
                return callback();

            return default(TResult);
        }

        /// <summary>
        /// This method checks wether a flag is set. This method can be used on enums or integral value types except <see cref="Char"/>.
        /// </summary>
        /// <typeparam name="T">The type parameter of the checked type.</typeparam>
        /// <param name="target">Target value to check wether it has the flag or not.</param>
        /// <param name="value">The value of the flag to check.</param>
        /// <returns>
        /// Returns <c>true</c> if the <paramref name="value"/> is present in <paramref name="target"/>, otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the method is used on structs which are not integral value types or are <see cref="Char">chars</see>, the method will always return <c>false</c>.
        /// </para>
        /// <para>
        /// This method can even evaluate flag values on integral types which are not enums.
        /// </para>
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag")]
        public static bool HasFlag<T>(this T target, T value)
            where T : struct
        {
            Type typeOfT = typeof(T);
            Type numericalType = null;
            int numericalTypeIndex;

            if (typeOfT.IsEnum && Enum.IsDefined(typeOfT, value))
            {
                numericalType = Enum.GetUnderlyingType(typeOfT);
                numericalTypeIndex = Array.IndexOf(StructExtensions.IntegralTypes, numericalType);
            }
            else
            {
                numericalTypeIndex = Array.IndexOf(StructExtensions.IntegralTypes, typeOfT);
                if (numericalTypeIndex >= 0)
                    numericalType = typeOfT;
            }

            if (numericalType != null && numericalTypeIndex >= 0)
            {
                if ((numericalTypeIndex % 2) == 0)
                {
                    UInt64 a = (UInt64)Convert.ChangeType(target, typeof(UInt64), CultureInfo.InvariantCulture);
                    UInt64 b = (UInt64)Convert.ChangeType(value, typeof(UInt64), CultureInfo.InvariantCulture);

                    return a == (a | b);
                }
                else
                {
                    Int64 a = (Int64)Convert.ChangeType(target, typeof(Int64), CultureInfo.InvariantCulture);
                    Int64 b = (Int64)Convert.ChangeType(value, typeof(Int64), CultureInfo.InvariantCulture);

                    return a == (a | b);
                }
            }

            return false;
        }
    }
}
