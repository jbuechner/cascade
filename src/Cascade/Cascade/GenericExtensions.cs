using System;

namespace Cascade
{
    /// <summary>
    /// The static <i>GenericExtensions</i> class contains extension methods which can be applied to a wide number of objects or structures, because the target types are generic and does not
    /// having any concrete type constraints (beside <i>class</i> or <i>new</i>).
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// The method invokes multiple function calls which is executed in a sequence.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instanc.</param>
        /// <param name="callbacks">No, one or more callbacks which are called in order.</param>
        /// <remarks>
        /// <para>
        /// The extension can be usefull if multiple calls on an object instance are needed. The callbacks having the object as first argument, thus
        /// you are working on the same instance / value in all callbacks. But please not that assigning the argument to a new value inside a callback has no
        /// effect on the value of the object itself. If you need to assigne a new value inside the callbacks, you should use an other overload of Invoke.
        /// </para>
        /// <example>
        /// <code>
        /// interface IAnimal
        /// {
        ///     void Feed();
        ///     void Walk();
        /// }
        /// 
        /// public static void Main()
        /// {
        ///     IAnimal myPet = null;
        /// 
        ///     myPet.Invoke(t => t.Feed(), t => t.Walk());
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        public static void Invoke<T>(this T target, params Action<T>[] callbacks)
        {
            if (callbacks != null)
                foreach (Action<T> callback in callbacks)
                    callback(target);
        }

        /// <summary>
        /// The method invokes multiple function calls which is executed in a sequence.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instanc.e</param>
        /// <param name="callbacks">No, one or more callbacks which are called in order.</param>
        /// <remarks>
        /// <para>
        /// The extension can be usefull if multiple calls on an object instance are needed. The callbacks having the result of the previous
        /// callback passed in as the first argument. In case of the first callback the object / value itself is passed to the callback.
        /// You can use this Invoke overload to create new values and using them in subsequent invokes.
        /// </para>
        /// <example>
        /// <code>
        /// public static void Main()
        /// {
        ///     int value = 1;
        /// 
        ///     value = value.Invoke(t => { return t + 1; }, t => { return t * 4; }, t => { return t / 2; }); // 8
        /// }
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        public static T Invoke<T>(this T target, params Func<T, T>[] callbacks)
        {
            if (callbacks != null)
                foreach (Func<T, T> callback in callbacks)
                    target = callback(target);

            return target;
        }

        /// <summary>
        /// The methods gets the current value or a new value if the current value is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// Returns either the value of the object if it's not <c>null</c> or a newly created value of the target type.
        /// </returns>
        public static T GetValueOrNew<T>(this T target)
            where T : new()
        {
            if (target == null)
                return new T();

            return target;
        }

        /// <summary>
        /// The method gets either the value of this object or the <paramref name="defaultValue"/> if this object instance is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The method returns the object itself if it is not <c>null</c>. If the object instance is <c>null</c> the value of <paramref name="defaultValue"/> will be returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method can be used instead of the null-coalescing operator (if existing in your .NET language, like the <i>??</i> operator in <i>C#</i>).
        /// </para>
        /// </remarks>
        public static T GetValueOrDefault<T>(this T target, T defaultValue)
        {
            if (target == null)
                return defaultValue;

            return target;
        }

        /// <summary>
        /// The method will perform an action when the object instance is not <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="callback">A callback which is executed if <paramref name="target"/> is not <c>null</c>.</param>
        public static void IfNotNull<T>(this T target, Action<T> callback)
            where T : class
        {
            if (target != null && callback != null)
                callback(target);
        }

        /// <summary>
        /// The method will perform an action and returning its result when the object instance is not <c>null</c>.
        /// </summary>
        /// <typeparam name="TTarget">Type parameter for the target object.</typeparam>
        /// <typeparam name="TResult">Type parameter for the result value of the callback.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="callback">A callback which is executed if <paramref name="target"/> is not <c>null</c>.</param>
        /// <returns>
        /// Returns either <c>null</c> if <paramref name="target"/> is <c>null</c> or the return value of <paramref name="callback"/>. Returns <c>null</c>
        /// if <paramref name="callback"/> is <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method can be used together with the <see cref="IfNull&lt;TTarget, TResult>(TTarget, Func&lt;TResult>)"/> extensions to chain the calls to something like:
        /// <example>
        /// <code>
        /// static void Main()
        /// {
        ///     object target = null;
        ///     object result = null;
        ///     result = target.IfNotNull(t => { return t; }).IfNull(() => { return new object(); }); // result is new object()
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        public static TResult IfNotNull<TTarget, TResult>(this TTarget target, Func<TTarget, TResult> callback)
            where TTarget : class
        {
            if (target != null && callback != null)
                return callback(target);

            return default(TResult);
        }

        /// <summary>
        /// The method will perform an action when the object instance is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="callback">A callback which is executed if <paramref name="target"/> is <c>null</c>.</param>
        public static void IfNull<T>(this T target, Action callback)
            where T : class
        {
            if (callback != null && target == null)
                callback();
        }

        /// <summary>
        /// The method will perform an action and returning its result when the object instance not <c>null</c>.
        /// </summary>
        /// <typeparam name="TTarget">Type parameter for the target object.</typeparam>
        /// <typeparam name="TResult">Type parameter for the result value of the callback.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="callback">A callback which is executed if <paramref name="target"/> not <c>null</c>.</param>
        /// <returns>
        /// Returns either <c>null</c> if <paramref name="target"/> is not <c>null</c> or the return value of <paramref name="callback"/>. Returns <c>null</c>
        /// if <paramref name="callback"/> is <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method can be used together with the <see cref="IfNotNull&lt;TTarget, TResult>(TTarget, Func&lt;TTarget, TResult>)"/> extensions to chain the calls to something like:
        /// <example>
        /// <code>
        /// static void Main()
        /// {
        ///     object target = null;
        ///     object result = null;
        ///     result = target.IfNotNull(t => { return t; }).IfNull(() => { return new object(); }); // result is new object()
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        public static TResult IfNull<TTarget, TResult>(this TTarget target, Func<TResult> callback)
            where TTarget : class
        {
            if (callback != null && target == null)
                return callback();

            return default(TResult);
        }
    }
}
