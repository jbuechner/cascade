using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade.Data
{
    /// <summary>
    /// The static <i>ObjectExtensions</i> class contains extension methods usable on all types. In difference to <see cref="ObjectExtensions"/>,
    /// this class contains methods that are aware of types used in combination with database related code, like <see cref="System.DBNull"/>.
    /// </summary>
    public static class DatabaseObjectExtensions
    {
        public static DbMediator Db<T>(this T target)
        {
            return new DbMediator((object)target);
        }

        /// <summary>
        /// Returns <see cref="DBNull"/> for a <c>null</c> value, or the value itself.
        /// </summary>
        /// <param name="target">The target value to return.</param>
        /// <returns>
        /// Returns either <see cref="DBNull"/> is <paramref name="target"/> itself is null, otherwise <paramref name="target"/>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static object Value(this DbMediator target)
        {
            if (target == null || target.Value == null)
                return DBNull.Value;

            return target.Value;
        }

        /// <summary>
        /// The method checks wether the value is <c>null</c>.
        /// </summary>
        /// <param name="target">The target value to check.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="target"/> is either <c>null</c> or <see cref="System.DBNull"/>, otherwise <c>false</c>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static bool IsNull(this DbMediator target)
        {
            return target == null || target.IsNullOrDbNull;
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
        public static Boolean ToBoolean(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToBoolean(null);
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
        public static Boolean ToBoolean(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToBoolean(provider);
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
        public static Byte ToByte(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToByte(null);
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
        public static Byte ToByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToByte(provider);
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
        public static SByte ToSByte(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToSByte(null);
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
        public static SByte ToSByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToSByte(provider);
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
        public static Char ToChar(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToChar(null);
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
        public static Char ToChar(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToChar(provider);
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
        public static DateTime ToDateTime(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDateTime(null);
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
        public static DateTime ToDateTime(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDateTime(provider);
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
        public static TimeSpan ToTimeSpan(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

#if FW35
            return target.Value.ToTimeSpan();
#elif FW40
            return target.Value.ToTimeSpan(null);
#endif
        }

#if FW40
        public static TimeSpan ToTimeSpan(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToTimeSpan(provider);
        }
#endif

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
        public static Decimal ToDecimal(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDecimal(null);
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
        public static Decimal ToDecimal(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDecimal(provider);
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
        public static Double ToDouble(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDouble(null);
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
        public static Double ToDouble(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDouble(provider);
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
        public static Single ToSingle(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToSingle(null);
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
        public static Single ToSingle(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToSingle(provider);
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
        public static Int16 ToInt16(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt16(null);
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
        public static Int16 ToInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt16(provider);
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
        public static UInt16 ToUInt16(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt16(null);
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
        public static UInt16 ToUInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt16(provider);
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
        public static Int32 ToInt32(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt32(null);
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
        public static Int32 ToInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt32(provider);
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
        public static UInt32 ToUInt32(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt32(null);
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
        public static UInt32 ToUInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt32(provider);
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
        public static Int64 ToInt64(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt64(null);
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
        public static Int64 ToInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToInt64(provider);
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
        public static UInt64 ToUInt64(this DbMediator target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt64(null);
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
        public static UInt64 ToUInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt64(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Boolean>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Boolean>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Boolean? AsBoolean(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsBoolean(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Boolean? AsBoolean(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsBoolean(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Byte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Byte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Byte? AsByte(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsByte(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Byte? AsByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsByte(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;SByte>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;SByte>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static SByte? AsSByte(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSByte(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static SByte? AsSByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSByte(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Char>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Char>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Char? AsChar(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsChar(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Char? AsChar(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsChar(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;DateTime>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;DateTime>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.AsDateTime(object, IFormatProvider)"/> method. If <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static DateTime? AsDateTime(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDateTime(null);
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
        /// The method uses the <see cref="ObjectExtensions.AsDateTime(object, IFormatProvider)"/> method. If <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static DateTime? AsDateTime(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDateTime(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;TimeSpan>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;TimeSpan>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.AsTimeSpan"/> method. If <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static TimeSpan? AsTimeSpan(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

#if FW35
            return target.Value.AsTimeSpan();
#elif FW40
            return target.Value.AsTimeSpan(null);
#endif
        }

#if FW40
        public static TimeSpan? AsTimeSpan(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsTimeSpan(provider);
        }
#endif

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Decimal>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Decimal>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Decimal? AsDecimal(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDecimal(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Decimal? AsDecimal(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDecimal(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Double>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Double>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Double? AsDouble(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDouble(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Double? AsDouble(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDouble(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Single>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Single>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Single? AsSingle(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSingle(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Single? AsSingle(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSingle(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int16? AsInt16(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt16(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int16? AsInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt16(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt16>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt16>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt16? AsUInt16(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt16(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt16? AsUInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt16(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int32? AsInt32(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt32(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int32? AsInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt32(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt32>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt32>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt32? AsUInt32(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt32(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt32? AsUInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt32(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;Int64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;Int64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int64? AsInt64(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt64(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int64? AsInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt64(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable&lt;UInt64>"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable&lt;UInt64>"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt64? AsUInt64(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt64(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt64? AsUInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt64(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="String"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="String"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static string AsString(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsString(null);
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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static string AsString(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsString(provider);
        }
    }
}