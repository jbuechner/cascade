using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade.Data
{
    public static class DatabaseObjectExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static bool DbIsNull(this object target)
        {
            return target == null || Convert.IsDBNull(target);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Boolean? DbAsBoolean(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Boolean?>(t => Convert.ToBoolean(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Byte? DbAsByte(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Byte?>(t => Convert.ToByte(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static SByte? DbAsSByte(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<SByte?>(t => Convert.ToSByte(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Char? DbAsChar(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Char?>(t => Convert.ToChar(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static DateTime? DbAsDateTime(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.AsDateTime();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static TimeSpan? DbAsTimeSpan(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.AsTimeSpan();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Decimal? DbAsDecimal(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Decimal?>(t => Convert.ToDecimal(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Double? DbAsDouble(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Double?>(t => Convert.ToDouble(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Single? DbAsSingle(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Single?>(t => Convert.ToSingle(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int16? DbAsInt16(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Int16?>(t => Convert.ToInt16(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt16? DbAsUInt16(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<UInt16?>(t => Convert.ToUInt16(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int32? DbAsInt32(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Int32?>(t => Convert.ToInt32(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt32? DbAsUInt32(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<UInt32?>(t => Convert.ToUInt32(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static Int64? DbAsInt64(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<Int64?>(t => Convert.ToInt64(target));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static UInt64? DbAsUInt64(this object target)
        {
            if (target == null || Convert.IsDBNull(target))
                return null;

            return target.DynamicCast<UInt64?>(t => Convert.ToUInt64(target));
        }
    }
}
