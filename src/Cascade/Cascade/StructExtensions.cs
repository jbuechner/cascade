using System;

namespace Cascade
{
    /// <summary>
    /// The static <i>StructExtensions</i> class contains extension methods which are used for structures.
    /// </summary>
    public static class StructExtensions
    {
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
    }
}
