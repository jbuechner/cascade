using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static bool IsNull(this object target)
        {
            return target == null;
        }

        public static T StaticCast<T>(this object target, Func<object, T> castCallback)
        {
            if (target is T)
                return (T)target;

            if (target == null)
                throw new InvalidCastException(string.Format("Can not perform static cast to \"{0}\" on null value.", typeof(T).Name));

            if (castCallback != null)
                return castCallback(target);

            throw new InvalidCastException(string.Format("Can not perform static cast to \"{1}\" on type \"{0}\".", target.GetType().Name, typeof(T).Name));
        }

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

        public static Boolean ToBoolean(this object target)
        {
            return target.StaticCast<Boolean>(t => Convert.ToBoolean(target));
        }

        public static Byte ToByte(this object target)
        {
            return target.StaticCast<Byte>(t => Convert.ToByte(target));
        }

        public static SByte ToSByte(this object target)
        {
            return target.StaticCast<SByte>(t => Convert.ToSByte(target));
        }

        public static Char ToChar(this object target)
        {
            return target.StaticCast<Char>(t => Convert.ToChar(target));
        }

        public static DateTime ToDateTime(this object target)
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

                    return Convert.ToDateTime(target);
                });
        }

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

        public static Decimal ToDecimal(this object target)
        {
            return target.StaticCast<Decimal>(t => Convert.ToDecimal(target));
        }

        public static Double ToDouble(this object target)
        {
            return target.StaticCast<Double>(t => Convert.ToDouble(target));
        }

        public static Single ToSingle(this object target)
        {
            return target.StaticCast<Single>(t => Convert.ToSingle(target));
        }

        public static Int16 ToInt16(this object target)
        {
            return target.StaticCast<Int16>(t => Convert.ToInt16(target));
        }

        public static UInt16 ToUInt16(this object target)
        {
            return target.StaticCast<UInt16>(t => Convert.ToUInt16(target));
        }

        public static Int32 ToInt32(this object target)
        {
            return target.StaticCast<Int32>(t => Convert.ToInt32(target));
        }

        public static UInt32 ToUInt32(this object target)
        {
            return target.StaticCast<UInt32>(t => Convert.ToUInt32(target));
        }

        public static Int64 ToInt64(this object target)
        {
            return target.StaticCast<Int64>(t => Convert.ToInt64(target));
        }

        public static UInt64 ToUInt64(this object target)
        {
            return target.StaticCast<UInt64>(t => Convert.ToUInt64(target));
        }



        public static Boolean? AsBoolean(this object target)
        {
            return target.DynamicCast<Boolean?>(t => Convert.ToBoolean(target));
        }

        public static Byte? AsByte(this object target)
        {
            return target.DynamicCast<Byte?>(t => Convert.ToByte(target));
        }

        public static SByte? AsSByte(this object target)
        {
            return target.DynamicCast<SByte?>(t => Convert.ToSByte(target));
        }

        public static Char? AsChar(this object target)
        {
            return target.DynamicCast<Char?>(t => Convert.ToChar(target));
        }

        public static DateTime? AsDateTime(this object target)
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

                    return Convert.ToDateTime(target);
                });
        }

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

        public static Decimal? AsDecimal(this object target)
        {
            return target.DynamicCast<Decimal?>(t => Convert.ToDecimal(target));
        }

        public static Double? AsDouble(this object target)
        {
            return target.DynamicCast<Double?>(t => Convert.ToDouble(target));
        }

        public static Single? AsSingle(this object target)
        {
            return target.DynamicCast<Single?>(t => Convert.ToSingle(target));
        }

        public static Int16? AsInt16(this object target)
        {
            return target.DynamicCast<Int16?>(t => Convert.ToInt16(target));
        }

        public static UInt16? AsUInt16(this object target)
        {
            return target.DynamicCast<UInt16?>(t => Convert.ToUInt16(target));
        }

        public static Int32? AsInt32(this object target)
        {
            return target.DynamicCast<Int32?>(t => Convert.ToInt32(target));
        }

        public static UInt32? AsUInt32(this object target)
        {
            return target.DynamicCast<UInt32?>(t => Convert.ToUInt32(target));
        }

        public static Int64? AsInt64(this object target)
        {
            return target.DynamicCast<Int64?>(t => Convert.ToInt64(target));
        }

        public static UInt64? AsUInt64(this object target)
        {
            return target.DynamicCast<UInt64?>(t => Convert.ToUInt64(target));
        }
    }
}