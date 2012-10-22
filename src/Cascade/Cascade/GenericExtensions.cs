using System;
using System.Globalization;

namespace Cascade
{
    /// <summary>
    /// The static <i>GenericExtensions</i> class contains extension methods which can be applied to a wide number of typs, because the target types are generic and does not
    /// having any concrete type constraints (beside modifier like <i>class</i>, <i>struct</i> or <i>new</i>).
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// The method performs a static cast.
        /// </summary>
        /// <typeparam name="TIn">Type parameter for the target type of this extension.</typeparam>
        /// <typeparam name="TOut">Type parameter of the return value of this extension.</typeparam>
        /// <param name="target">Target of the static cast.</param>
        /// <returns>
        /// Returns a value of type <typeparamref name="TOut"/> or raises exceptions if the static cast can not be applied.
        /// </returns>
        public static TOut To<TOut, TIn>(this TIn target)
        {
            return (TOut)(object)target;
        }

        /// <summary>
        /// The method performs a dynamic cast.
        /// </summary>
        /// <typeparam name="TIn">Type parameter for the target type of this extension.</typeparam>
        /// <typeparam name="TOut">Type parameter of the return value of this extension.</typeparam>
        /// <param name="target">Target of the dynamic cast.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="TOut"/> if the dynamic cast was successful or the default value of <typeparamref name="TOut"/> if <paramref name="target"/>
        /// is not of type <typeparamref name="TOut"/>.
        /// </returns>
        public static TOut As<TIn, TOut>(this TIn target)
        {
            if (target is TOut)
                return (TOut)(object)target;

            return default(TOut);
        }

        /// <summary>
        /// The method checks whether the value is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Target type for this extension.</typeparam>
        /// <param name="target">Target of the check.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="target"/> is <c>null</c>, otherwise <c>false</c>.
        /// </returns>
        public static bool IsNull<T>(this T target)
        {
            return target == null;
        }

        /// <summary>
        /// The method checks whether the value is not <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Target type for this extension.</typeparam>
        /// <param name="target">Target of the check.</param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this T target)
        {
            return target != null;
        }

        /// <summary>
        /// The method performs a static cast on the object and returns the value in form of a certain type.
        /// </summary>
        /// <typeparam name="TIn">Target type for this extension.</typeparam>
        /// <typeparam name="TOut">Result type of the static cast.</typeparam>
        /// <param name="target">Target of the static cast.</param>
        /// <param name="castCallback">A callback used if <paramref name="target"/> is not already of type <typeparamref name="TIn"/>.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="TOut"/> or the default value of <typeparamref name="TOut"/> if returned by <paramref name="castCallback"/>.</returns>
        /// <exception cref="InvalidCastException">Is raised when <paramref name="target"/> is <c>null</c> or the value is not of type <typeparamref name="TOut"/> and <paramref name="castCallback"/>
        /// is <c>null</c>.</exception>
        public static TOut StaticCast<TIn, TOut>(this TIn target, Func<TIn, TOut> castCallback)
        {
            if (target is TOut)
                return (TOut)(object)target;

            if (target == null)
                throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture, "Can not perform static cast to \"{0}\" on null value.", typeof(TOut).Name));

            if (castCallback != null)
                return castCallback(target);

            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture, "Can not perform static cast to \"{1}\" on type \"{0}\".", target.GetType().Name, typeof(TOut).Name));
        }

        /// <summary>
        /// The method performs a dynamic cast on the object and returns the value in a given type.
        /// </summary>
        /// <typeparam name="TIn">The target type for this extension.</typeparam>
        /// <typeparam name="TOut">Result type of the dynamic cast.</typeparam>
        /// <param name="target">Target of the dynamic cast.</param>
        /// <param name="castCallback">A callback used if <paramref name="target"/> is not of type <typeparamref name="TOut"/> and if <paramref name="target"/> is not <c>null</c>.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="TOut"/> or the default value of <typeparamref name="TOut"/> if <paramref name="target"/> is not of type <typeparamref name="TOut"/>,
        /// is <c>null</c> or if <paramref name="castCallback"/> is null.
        /// </returns>
        /// <remarks>
        /// The method performs exactly like <see cref="StaticCast"/>, but do not raise exceptions if <paramref name="target"/> is <c>null</c> or is not of type <typeparamref name="TOut"/>. In addition
        /// any <see cref="FormatException"/>, <see cref="InvalidCastException"/> and <see cref="OverflowException"/> is catched by this method and the default value of <typeparamref name="TOut"/> is
        /// returned instead.
        /// </remarks>
        public static TOut DynamicCast<TIn, TOut>(this TIn target, Func<TIn, TOut> castCallback)
        {
            if (target is TIn)
                return (TOut)(object)target;

            if (target == null)
                return default(TOut);

            if (castCallback != null)
                try
                {
                    return castCallback(target);
                }
                catch (FormatException)
                {
                }
                catch (InvalidCastException)
                {
                }
                catch (OverflowException)
                {
                }

            return default(TOut);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Boolean"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Boolean"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>.
        /// </remarks>
        public static Boolean ToBoolean<T>(this T target)
        {
            return target.ToBoolean(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Boolean"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Boolean"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.
        /// </remarks>
        public static Boolean ToBoolean<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Boolean>(t => Convert.ToBoolean(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Byte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>.
        /// </remarks>
        public static Byte ToByte<T>(this T target)
        {
            return target.ToByte<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Byte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static Byte ToByte<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Byte>(t => Convert.ToByte(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="SByte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>.
        /// </remarks>
        public static SByte ToSByte<T>(this T target)
        {
            return target.ToSByte<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="SByte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static SByte ToSByte<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, SByte>(t => Convert.ToSByte(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Char"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Char"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>.
        /// </remarks>
        public static Char ToChar<T>(this T target)
        {
            return target.ToChar<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Char"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Char"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.
        /// </remarks>
        public static Char ToChar<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Char>(t => Convert.ToChar(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="DateTime"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="DateTime"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime ToDateTime<T>(this T target)
        {
            return target.ToDateTime<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="DateTime"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="DateTime"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime ToDateTime<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, DateTime>(
                t =>
                {
                    if (t is Byte)
                        return new DateTime((Byte)(object)t);
                    if (t is SByte)
                    {
                        SByte value = (SByte)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int16)
                    {
                        Int16 value = (Int16)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int32)
                    {
                        Int32 value = (Int32)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int64)
                    {
                        Int64 value = (Int64)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is UInt16)
                        return new DateTime((UInt16)(object)t);
                    if (t is UInt32)
                        return new DateTime((UInt32)(object)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)(object)t;
                        if (value <= Int32.MaxValue)
                            return new DateTime((Int32)value);
                    }

                    return Convert.ToDateTime(target, provider);
                });
        }

#if FW40
        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="TimeSpan.Parse(string)"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
        public static TimeSpan ToTimeSpan<T>(this T target)
        {
            return target.ToTimeSpan<T>(null);
        }
#endif

#if FW35
        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="TimeSpan.Parse"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
#elif FW40
        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="TimeSpan.Parse(string, IFormatProvider)"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
#endif
        public static TimeSpan ToTimeSpan<T>(
            this T target
#if FW40
            ,IFormatProvider provider
#endif
            )
        {
            return target.StaticCast<T, TimeSpan>(t =>
            {
                if (t is Byte)
                    return new TimeSpan((Byte)(object)t);
                if (t is SByte)
                    return new TimeSpan((SByte)(object)t);
                if (t is Int16)
                    return new TimeSpan((Int16)(object)t);
                if (t is Int32)
                    return new TimeSpan((Int32)(object)t);
                if (t is Int64)
                    return new TimeSpan((Int64)(object)t);
                if (t is UInt16)
                    return new TimeSpan((UInt16)(object)t);
                if (t is UInt32)
                    return new TimeSpan((UInt32)(object)t);
                if (t is UInt64)
                {
                    UInt64 value = (UInt64)(object)t;
                    if (value <= Int32.MaxValue)
                        return new TimeSpan((Int32)value);
                }
                
#if FW35
                return TimeSpan.Parse(target.ToString());
#elif FW40
                return TimeSpan.Parse(target.ToString(), provider);
#endif
            });
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Decimal"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Decimal"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>.
        /// </remarks>
        public static Decimal ToDecimal<T>(this T target)
        {
            return target.ToDecimal<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Decimal"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Decimal"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.
        /// </remarks>
        public static Decimal ToDecimal<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Decimal>(t => Convert.ToDecimal(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Double"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>.
        /// </remarks>
        public static Double ToDouble<T>(this T target)
        {
            return target.ToDouble<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Double"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.
        /// </remarks>
        public static Double ToDouble<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Double>(t => Convert.ToDouble(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Single"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>.
        /// </remarks>
        public static Single ToSingle<T>(this T target)
        {
            return target.ToSingle<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Single"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// </remarks>
        public static Single ToSingle<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Single>(t => Convert.ToSingle(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>.
        /// </remarks>
        public static Int16 ToInt16<T>(this T target)
        {
            return target.ToInt16<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int16 ToInt16<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Int16>(t => Convert.ToInt16(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>.
        /// </remarks>
        public static UInt16 ToUInt16<T>(this T target)
        {
            return target.ToUInt16<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt16 ToUInt16<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, UInt16>(t => Convert.ToUInt16(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32 ToInt32<T>(this T target)
        {
            return target.ToInt32<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int32 ToInt32<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Int32>(t => Convert.ToInt32(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>.
        /// </remarks>
        public static UInt32 ToUInt32<T>(this T target)
        {
            return target.ToUInt32<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt32 ToUInt32<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, UInt32>(t => Convert.ToUInt32(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>.
        /// </remarks>
        public static Int64 ToInt64<T>(this T target)
        {
            return target.ToInt64<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int64 ToInt64<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, Int64>(t => Convert.ToInt64(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>.
        /// </remarks>
        public static UInt64 ToUInt64<T>(this T target)
        {
            return target.ToUInt64<T>(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt64 ToUInt64<T>(this T target, IFormatProvider provider)
        {
            return target.StaticCast<T, UInt64>(t => Convert.ToUInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Boolean}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Boolean}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>.
        /// </remarks>
        public static Boolean? AsBoolean<T>(this T target)
        {
            return target.AsBoolean<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Boolean}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Boolean}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.
        /// </remarks>
        public static Boolean? AsBoolean<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Boolean?>(t => Convert.ToBoolean(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Byte}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Byte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>.
        /// </remarks>
        public static Byte? AsByte<T>(this T target)
        {
            return target.AsByte<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Byte}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Byte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static Byte? AsByte<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Byte?>(t => Convert.ToByte(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{SByte}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{SByte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>.
        /// </remarks>
        public static SByte? AsSByte<T>(this T target)
        {
            return target.AsSByte<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{SByte}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{SByte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static SByte? AsSByte<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, SByte?>(t => Convert.ToSByte(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Char}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Char}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>.
        /// </remarks>
        public static Char? AsChar<T>(this T target)
        {
            return target.AsChar<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Char}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Char}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.
        /// </remarks>
        public static Char? AsChar<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Char?>(t => Convert.ToChar(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{DateTime}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{DateTime}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime? AsDateTime<T>(this T target)
        {
            return target.AsDateTime<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{DateTime}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{DateTime}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime? AsDateTime<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, DateTime?>(
                t =>
                {
                    if (t is Byte)
                        return new DateTime((Byte)(object)t);
                    if (t is SByte)
                    {
                        SByte value = (SByte)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int16)
                    {
                        Int16 value = (Int16)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int32)
                    {
                        Int32 value = (Int32)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is Int64)
                    {
                        Int64 value = (Int64)(object)t;
                        if (value >= 0)
                            return new DateTime(value);
                    }
                    if (t is UInt16)
                        return new DateTime((UInt16)(object)t);
                    if (t is UInt32)
                        return new DateTime((UInt32)(object)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)(object)t;
                        if (value <= Int32.MaxValue)
                            return new DateTime((Int32)value);
                    }

                    return Convert.ToDateTime(target, provider);
                });
        }

#if FW40
        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{DateTime}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{DateTime}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static TimeSpan? AsTimeSpan<T>(this T target)
        {
            return target.AsTimeSpan<T>(null);
        }
#endif

#if FW35
        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{TimeSpan}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{TimeSpan}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.TimeSpan.Parse(string)"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
#elif FW40
        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{TimeSpan}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.TimeSpan.TryParse(string, IFormatProvider, out TimeSpan)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{TimeSpan}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.TimeSpan.TryParse(string, IFormatProvider, out TimeSpan)"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
#endif
        public static TimeSpan? AsTimeSpan<T>(
            this T target
#if FW40
            ,IFormatProvider provider
#endif
            )
        {
            return target.DynamicCast<T, TimeSpan?>(t =>
            {
                if (t is Byte)
                    return new TimeSpan((Byte)(object)t);
                if (t is SByte)
                    return new TimeSpan((SByte)(object)t);
                if (t is Int16)
                    return new TimeSpan((Int16)(object)t);
                if (t is Int32)
                    return new TimeSpan((Int32)(object)t);
                if (t is Int64)
                    return new TimeSpan((Int64)(object)t);
                if (t is UInt16)
                    return new TimeSpan((UInt16)(object)t);
                if (t is UInt32)
                    return new TimeSpan((UInt32)(object)t);
                if (t is UInt64)
                {
                    UInt64 value = (UInt64)(object)t;
                    if (value <= Int32.MaxValue)
                        return new TimeSpan((Int32)value);
                }

                TimeSpan timeSpanValue;
#if FW40
                if (TimeSpan.TryParse(target.ToString(), provider, out timeSpanValue))
                return timeSpanValue;
#elif FW35
                if (TimeSpan.TryParse(target.ToString(), out timeSpanValue))
                    return timeSpanValue;
#endif

                return null;
            });
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Decimal}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Decimal}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>.
        /// </remarks>
        public static Decimal? AsDecimal<T>(this T target)
        {
            return target.AsDecimal<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Decimal}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Decimal}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.
        /// </remarks>
        public static Decimal? AsDecimal<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Decimal?>(t => Convert.ToDecimal(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Double}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Double}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>.
        /// </remarks>
        public static Double? AsDouble<T>(this T target)
        {
            return target.AsDouble<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Double}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Double}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.
        /// </remarks>
        public static Double? AsDouble<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Double?>(t => Convert.ToDouble(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Single}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Single}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>.
        /// </remarks>
        public static Single? AsSingle<T>(this T target)
        {
            return target.AsSingle<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Single}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Single}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// </remarks>
        public static Single? AsSingle<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Single?>(t => Convert.ToSingle(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int16}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>.
        /// </remarks>
        public static Int16? AsInt16<T>(this T target)
        {
            return target.AsInt16<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int16}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int16? AsInt16<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Int16?>(t => Convert.ToInt16(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt16}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>.
        /// </remarks>
        public static UInt16? AsUInt16<T>(this T target)
        {
            return target.AsUInt16<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt16}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt16? AsUInt16<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, UInt16?>(t => Convert.ToUInt16(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int32}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32? AsInt32<T>(this T target)
        {
            return target.AsInt32<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int32}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32? AsInt32<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Int32?>(t => Convert.ToInt32(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt32}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>.
        /// </remarks>
        public static UInt32? AsUInt32<T>(this T target)
        {
            return target.AsUInt32<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt32}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt32? AsUInt32<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, UInt32?>(t => Convert.ToUInt32(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int64}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>.
        /// </remarks>
        public static Int64? AsInt64<T>(this T target)
        {
            return target.AsInt64<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int64}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int64? AsInt64<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, Int64?>(t => Convert.ToInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt64}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>.
        /// </remarks>
        public static UInt64? AsUInt64<T>(this T target)
        {
            return target.AsUInt64<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt64}"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt64? AsUInt64<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, UInt64?>(t => Convert.ToUInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="String"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="String"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object)"/>.
        /// </remarks>
        public static string AsString<T>(this T target)
        {
            return target.AsString<T>(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="String"/>.
        /// </summary>
        /// <typeparam name="T">Target type of the extension</typeparam>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToString(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="String"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object, IFormatProvider)"/>.
        /// </remarks>
        public static string AsString<T>(this T target, IFormatProvider provider)
        {
            return target.DynamicCast<T, string>(t => Convert.ToString(target, provider));
        }

        /// <summary>
        /// The method invokes multiple function calls which are executed in a sequence.
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
        /// The method invokes multiple function calls which are executed in a sequence.
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
        /// The method gets either the value of this object or the <paramref name="defaultValue"/> if this object instance is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">Type parameter for the target object.</typeparam>
        /// <param name="target">The target object instance.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The method returns the object itself if it is not <c>null</c>. If the object is <c>null</c> <paramref name="defaultValue"/> is returned.
        /// </returns>
        /// <remarks>
        /// <para>
        /// In difference to the <see cref="GetValueOrDefault{T}(T, T)"/> overload, this overload will accept any value as default value and return it. So you can
        /// return default value which are not of <typeparamref name="T"/>.
        /// </para>
        /// </remarks>
        public static object GetValueOrDefault<T>(this T target, object defaultValue)
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
        /// This method can be used together with the <see cref="IfNull{TTarget, TResult}(TTarget, Func{TResult})"/> extensions to chain the calls to something like:
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
        /// This method can be used together with the <see cref="IfNotNull{TTarget, TResult}(TTarget, Func{TTarget, TResult})"/> extensions to chain the calls to something like:
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
