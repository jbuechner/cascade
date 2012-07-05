using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Cascade
{
    /// <summary>
    /// The static <i>ObjectExtensions</i> class contains extension methods usable on all types.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// The method performs a static cast.
        /// </summary>
        /// <typeparam name="T">Result type of the static cast.</typeparam>
        /// <param name="target">Target of the static cast.</param>
        /// <returns>
        /// Returns a value of type <typeparamref name="T"/> or raises exceptions if the static cast can not be applied.
        /// </returns>
        public static T To<T>(this object target)
        {
            return (T)target;
        }

        /// <summary>
        /// The method performs a dynamic cast.
        /// </summary>
        /// <typeparam name="T">Result type of the dynamic cast.</typeparam>
        /// <param name="target">Target of the dynamic cast.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="T"/> if the dynamic cast was performed successful or the default value of <typeparamref name="T"/> if <paramref name="target"/>
        /// is not of type <typeparamref name="T"/>.
        /// </returns>
        public static T As<T>(this object target)
        {
            if (target is T)
                return (T)target;

            return default(T);
        }

        /// <summary>
        /// The method checks wether the value is <c>null</c>.
        /// </summary>
        /// <param name="target">Target of the check.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="target"/> is <c>null</c>, otherwise <c>false</c>.
        /// </returns>
        public static bool IsNull(this object target)
        {
            return target == null;
        }

        /// <summary>
        /// The method performs a static cast on the object and returns the value in a given type.
        /// </summary>
        /// <typeparam name="T">Result type of the static cast.</typeparam>
        /// <param name="target">Target of the static cast.</param>
        /// <param name="castCallback">A callback used if <paramref name="target"/> is not already of type <typeparamref name="T"/>.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="T"/> or the default value of <typeparamref name="T"/> if returned by <paramref name="castCallback"/>.
        /// </returns>
        /// <exception cref="InvalidCastException">Is raised when <paramref name="target"/> is <c>null</c> or the value is not of type <typeparamref name="T"/> and <paramref name="castCallback"/>
        /// is <c>null</c>.</exception>
        public static T StaticCast<T>(this object target, Func<object, T> castCallback)
        {
            if (target is T)
                return (T)target;

            if (target == null)
                throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,  "Can not perform static cast to \"{0}\" on null value.", typeof(T).Name));

            if (castCallback != null)
                return castCallback(target);

            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture, "Can not perform static cast to \"{1}\" on type \"{0}\".", target.GetType().Name, typeof(T).Name));
        }

        /// <summary>
        /// The method performs a dynamic cast on the object and returns the value in a given type.
        /// </summary>
        /// <typeparam name="T">Result type of the dynamic cast.</typeparam>
        /// <param name="target">Target of the dynamic cast.</param>
        /// <param name="castCallback">A callback used if <paramref name="target"/> is not of type <typeparamref name="T"/> and if <paramref name="target"/> is not <c>null</c>.</param>
        /// <returns>
        /// Returns either a value of type <typeparamref name="T"/> or the default value of <typeparamref name="T"/> if <paramref name="target"/> is not of type <typeparamref name="T"/>,
        /// is <c>null</c> or if <paramref name="castCallback"/> is null.
        /// </returns>
        /// <remarks>
        /// The method performs exactly like <see cref="StaticCast"/>, but do not raise exceptions if <paramref name="target"/> is <c>null</c> or not of the type <typeparamref name="T"/>. In addition
        /// any <see cref="FormatException"/>, <see cref="InvalidCastException"/> and <see cref="OverflowException"/> is catched by this method and the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </remarks>
        public static T DynamicCast<T>(this object target, Func<object, T> castCallback)
        {
            if (target is T)
                return (T)target;

            if (target == null)
                return default(T);

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

            return default(T);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Boolean"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Boolean"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>.
        /// </remarks>
        public static Boolean ToBoolean(this object target)
        {
            return target.ToBoolean(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Boolean"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Boolean"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.
        /// </remarks>
        public static Boolean ToBoolean(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Boolean>(t => Convert.ToBoolean(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Byte"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Byte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>.
        /// </remarks>
        public static Byte ToByte(this object target)
        {
            return target.ToByte(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Byte"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Byte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static Byte ToByte(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Byte>(t => Convert.ToByte(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="SByte"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="SByte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>.
        /// </remarks>
        public static SByte ToSByte(this object target)
        {
            return target.ToSByte(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="SByte"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="SByte"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static SByte ToSByte(this object target, IFormatProvider provider)
        {
            return target.StaticCast<SByte>(t => Convert.ToSByte(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Char"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Char"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>.
        /// </remarks>
        public static Char ToChar(this object target)
        {
            return target.ToChar(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Char"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Char"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.
        /// </remarks>
        public static Char ToChar(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Char>(t => Convert.ToChar(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="DateTime"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime ToDateTime(this object target)
        {
            return target.ToDateTime(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="DateTime"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime ToDateTime(this object target, IFormatProvider provider)
        {
            return target.StaticCast<DateTime>(
                t =>
                {
                    if (t is Byte)
                        return new DateTime((Byte)t);
                    if (t is SByte)
                    {
                        SByte value = (SByte)t;
                        if (value >= 0)
                            return new DateTime((SByte)t);
                    }
                    if (t is Int16)
                    {
                        Int16 value = (Int16)t;
                        if (value >= 0)
                            return new DateTime((Int16)t);
                    }
                    if (t is Int32)
                    {
                        Int32 value = (Int32)t;
                        if (value >= 0)
                            return new DateTime((Int32)t);
                    }
                    if (t is Int64)
                    {
                        Int64 value = (Int64)t;
                        if (value >= 0)
                            return new DateTime((Int64)t);
                    }
                    if (t is UInt16)
                        return new DateTime((UInt16)t);
                    if (t is UInt32)
                        return new DateTime((UInt32)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)t;
                        if (value <= Int32.MaxValue)
                            return new DateTime((Int32)value);
                    }

                    return Convert.ToDateTime(target, provider);
                });
        }

        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="TimeSpan.Parse"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
        public static TimeSpan ToTimeSpan(this object target)
        {
            return target.StaticCast<TimeSpan>(t =>
                {
                    if (t is Byte)
                        return new TimeSpan((Byte)t);
                    if (t is SByte)
                        return new TimeSpan((SByte)t);
                    if (t is Int16)
                        return new TimeSpan((Int16)t);
                    if (t is Int32)
                        return new TimeSpan((Int32)t);
                    if (t is Int64)
                        return new TimeSpan((Int64)t);
                    if (t is UInt16)
                        return new TimeSpan((UInt16)t);
                    if (t is UInt32)
                        return new TimeSpan((UInt32)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)t;
                        if (value <= Int32.MaxValue)
                            return new TimeSpan((Int32)value);
                    }

                    return TimeSpan.Parse(target.ToString());
                });
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Decimal"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Decimal"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>.
        /// </remarks>
        public static Decimal ToDecimal(this object target)
        {
            return target.ToDecimal(null);
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
        public static Decimal ToDecimal(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Decimal>(t => Convert.ToDecimal(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Double"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Double"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>.
        /// </remarks>
        public static Double ToDouble(this object target)
        {
            return target.ToDouble(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Double"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Double"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.
        /// </remarks>
        public static Double ToDouble(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Double>(t => Convert.ToDouble(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Single"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Single"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>.
        /// </remarks>
        public static Single ToSingle(this object target)
        {
            return target.ToSingle(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Single"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Single"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// </remarks>
        public static Single ToSingle(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Single>(t => Convert.ToSingle(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int16"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>.
        /// </remarks>
        public static Int16 ToInt16(this object target)
        {
            return target.ToInt16(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int16"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int16 ToInt16(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Int16>(t => Convert.ToInt16(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt16"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>.
        /// </remarks>
        public static UInt16 ToUInt16(this object target)
        {
            return target.ToUInt16(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt16"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt16"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt16 ToUInt16(this object target, IFormatProvider provider)
        {
            return target.StaticCast<UInt16>(t => Convert.ToUInt16(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int32"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32 ToInt32(this object target)
        {
            return target.ToInt32(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int32"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int32 ToInt32(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Int32>(t => Convert.ToInt32(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt32"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>.
        /// </remarks>
        public static UInt32 ToUInt32(this object target)
        {
            return target.ToUInt32(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt32"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt32"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt32 ToUInt32(this object target, IFormatProvider provider)
        {
            return target.StaticCast<UInt32>(t => Convert.ToUInt32(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int64"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="Int64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>.
        /// </remarks>
        public static Int64 ToInt64(this object target)
        {
            return target.ToInt64(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="Int64"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Int64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int64 ToInt64(this object target, IFormatProvider provider)
        {
            return target.StaticCast<Int64>(t => Convert.ToInt64(target, provider));
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt64"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="UInt64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>.
        /// </remarks>
        public static UInt64 ToUInt64(this object target)
        {
            return target.ToUInt64(null);
        }

        /// <summary>
        /// The method performs a static cast to <see cref="UInt64"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="UInt64"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt64 ToUInt64(this object target, IFormatProvider provider)
        {
            return target.StaticCast<UInt64>(t => Convert.ToUInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Boolean>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Boolean>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>.
        /// </remarks>
        public static Boolean? AsBoolean(this object target)
        {
            return target.AsBoolean(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Boolean>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Boolean>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.
        /// </remarks>
        public static Boolean? AsBoolean(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Boolean?>(t => Convert.ToBoolean(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Byte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Byte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>.
        /// </remarks>
        public static Byte? AsByte(this object target)
        {
            return target.AsByte(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Byte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Byte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static Byte? AsByte(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Byte?>(t => Convert.ToByte(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;SByte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;SByte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>.
        /// </remarks>
        public static SByte? AsSByte(this object target)
        {
            return target.AsSByte(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;SByte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;SByte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// </remarks>
        public static SByte? AsSByte(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<SByte?>(t => Convert.ToSByte(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Char>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Char>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>.
        /// </remarks>
        public static Char? AsChar(this object target)
        {
            return target.AsChar(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Char>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Char>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.
        /// </remarks>
        public static Char? AsChar(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Char?>(t => Convert.ToChar(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;DateTime>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;DateTime>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime? AsDateTime(this object target)
        {
            return target.AsDateTime(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;DateTime>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;DateTime>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        public static DateTime? AsDateTime(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<DateTime?>(
                t =>
                {
                    if (t is Byte)
                        return new DateTime((Byte)t);
                    if (t is SByte)
                    {
                        SByte value = (SByte)t;
                        if (value >= 0)
                            return new DateTime((SByte)t);
                    }
                    if (t is Int16)
                    {
                        Int16 value = (Int16)t;
                        if (value >= 0)
                            return new DateTime((Int16)t);
                    }
                    if (t is Int32)
                    {
                        Int32 value = (Int32)t;
                        if (value >= 0)
                            return new DateTime((Int32)t);
                    }
                    if (t is Int64)
                    {
                        Int64 value = (Int64)t;
                        if (value >= 0)
                            return new DateTime((Int64)t);
                    }
                    if (t is UInt16)
                        return new DateTime((UInt16)t);
                    if (t is UInt32)
                        return new DateTime((UInt32)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)t;
                        if (value <= Int32.MaxValue)
                            return new DateTime((Int32)value);
                    }

                    return Convert.ToDateTime(target, provider);
                });
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;TimeSpan>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;TimeSpan>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="TimeSpan.Parse"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
        public static TimeSpan? AsTimeSpan(this object target)
        {
            return target.DynamicCast<TimeSpan?>(t => 
                {
                    if (t is Byte)
                        return new TimeSpan((Byte)t);
                    if (t is SByte)
                        return new TimeSpan((SByte)t);
                    if (t is Int16)
                        return new TimeSpan((Int16)t);
                    if (t is Int32)
                        return new TimeSpan((Int32)t);
                    if (t is Int64)
                        return new TimeSpan((Int64)t);
                    if (t is UInt16)
                        return new TimeSpan((UInt16)t);
                    if (t is UInt32)
                        return new TimeSpan((UInt32)t);
                    if (t is UInt64)
                    {
                        UInt64 value = (UInt64)t;
                        if (value <= Int32.MaxValue)
                            return new TimeSpan((Int32)value);
                    }

                    TimeSpan timeSpanValue;
                    if (TimeSpan.TryParse(target.ToString(), out timeSpanValue))
                        return timeSpanValue;

                    return null;
                });
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Decimal>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Decimal>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>.
        /// </remarks>
        public static Decimal? AsDecimal(this object target)
        {
            return target.AsDecimal(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Decimal>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Decimal>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.
        /// </remarks>
        public static Decimal? AsDecimal(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Decimal?>(t => Convert.ToDecimal(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Double>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Double>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>.
        /// </remarks>
        public static Double? AsDouble(this object target)
        {
            return target.AsDouble(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Double>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Double>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.
        /// </remarks>
        public static Double? AsDouble(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Double?>(t => Convert.ToDouble(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Single>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Single>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>.
        /// </remarks>
        public static Single? AsSingle(this object target)
        {
            return target.AsSingle(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Single>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Single>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// </remarks>
        public static Single? AsSingle(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Single?>(t => Convert.ToSingle(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>.
        /// </remarks>
        public static Int16? AsInt16(this object target)
        {
            return target.AsInt16(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int16? AsInt16(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Int16?>(t => Convert.ToInt16(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>.
        /// </remarks>
        public static UInt16? AsUInt16(this object target)
        {
            return target.AsUInt16(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt16? AsUInt16(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<UInt16?>(t => Convert.ToUInt16(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32? AsInt32(this object target)
        {
            return target.AsInt32(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        public static Int32? AsInt32(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Int32?>(t => Convert.ToInt32(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>.
        /// </remarks>
        public static UInt32? AsUInt32(this object target)
        {
            return target.AsUInt32(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt32? AsUInt32(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<UInt32?>(t => Convert.ToUInt32(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>.
        /// </remarks>
        public static Int64? AsInt64(this object target)
        {
            return target.AsInt64(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static Int64? AsInt64(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<Int64?>(t => Convert.ToInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>.
        /// </remarks>
        public static UInt64? AsUInt64(this object target)
        {
            return target.AsUInt64(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.
        /// </remarks>
        public static UInt64? AsUInt64(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<UInt64?>(t => Convert.ToUInt64(target, provider));
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="String"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="String"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object)"/>.
        /// </remarks>
        public static string AsString(this object target)
        {
            return target.AsString(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="String"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToString(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="String"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object, IFormatProvider)"/>.
        /// </remarks>
        public static string AsString(this object target, IFormatProvider provider)
        {
            return target.DynamicCast<string>(t => Convert.ToString(target, provider));
        }
    }
}