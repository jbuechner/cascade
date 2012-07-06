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
        /// <summary>
        /// Returns <see cref="DBNull"/> for a <c>null</c> value, or the value itself.
        /// </summary>
        /// <param name="target">The target value to return.</param>
        /// <returns>
        /// Returns either <see cref="DBNull"/> is <paramref name="target"/> itself is null, otherwise <paramref name="target"/>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static object ToDbValue(this object target)
        {
            if (target == null)
                return DBNull.Value;

            return target;
        }

        /// <summary>
        /// The method checks wether the value is <c>null</c>.
        /// </summary>
        /// <param name="target">The target value to check.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="target"/> is either <c>null</c> or <see cref="System.DBNull"/>, otherwise <c>false</c>.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static bool DbIsNull(this object target)
        {
            return target == null || Convert.IsDBNull(target);
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
        public static Boolean? DbAsBoolean(this object target)
        {
            return target.DbAsBoolean(null);
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
        public static Boolean? DbAsBoolean(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Byte? DbAsByte(this object target)
        {
            return target.DbAsByte(null);
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
        public static Byte? DbAsByte(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static SByte? DbAsSByte(this object target)
        {
            return target.DbAsSByte(null);
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
        public static SByte? DbAsSByte(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Char? DbAsChar(this object target)
        {
            return target.DbAsChar(null);
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
        public static Char? DbAsChar(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.AsDateTime(object, IFormatProvider)"/> method. If <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static DateTime? DbAsDateTime(this object target)
        {
            return target.DbAsDateTime(null);
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
        public static DateTime? DbAsDateTime(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.AsDateTime(provider);
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
        public static TimeSpan? DbAsTimeSpan(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.AsTimeSpan();
        }

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
        public static Decimal? DbAsDecimal(this object target)
        {
            return target.DbAsDecimal(null);
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
        public static Decimal? DbAsDecimal(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Double? DbAsDouble(this object target)
        {
            return target.DbAsDouble(null);
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
        public static Double? DbAsDouble(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Single? DbAsSingle(this object target)
        {
            return target.DbAsSingle(null);
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
        public static Single? DbAsSingle(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int16? DbAsInt16(this object target)
        {
            return target.DbAsInt16(null);
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
        public static Int16? DbAsInt16(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt16? DbAsUInt16(this object target)
        {
            return target.DbAsUInt16(null);
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
        public static UInt16? DbAsUInt16(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int32? DbAsInt32(this object target)
        {
            return target.DbAsInt32(null);
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
        public static Int32? DbAsInt32(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt32? DbAsUInt32(this object target)
        {
            return target.DbAsUInt32(null);
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
        public static UInt32? DbAsUInt32(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int64? DbAsInt64(this object target)
        {
            return target.DbAsInt64(null);
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
        public static Int64? DbAsInt64(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt64? DbAsUInt64(this object target)
        {
            return target.DbAsUInt64(null);
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
        public static UInt64? DbAsUInt64(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

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
        /// The method uses the <see cref="ObjectExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object)"/>. If <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static string DbAsString(this object target)
        {
            return target.DbAsString(null);
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
        public static string DbAsString(this object target, IFormatProvider provider)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<string>(t => Convert.ToString(target, provider));
        }
    }
}