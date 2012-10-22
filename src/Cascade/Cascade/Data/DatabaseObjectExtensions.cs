using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade.Data
{
    /// <summary>
    /// The static <i>DatabaseObjectExtensions</i> class contains extension methods usable on <see cref="DbMediator"/> objects. The extensions are used when
    /// working with database values.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Before you can use an database object extensions you need an object of type <see cref="DbMediator"/>. You can either create your own by using the class
    /// constructor or by using the extension method <see cref="DatabaseObjectExtensions.Db{T}"/>. All other extension methods in this class are only applicable
    /// on <see cref="DbMediator"/> objects.
    /// </para>
    /// </remarks>
    public static class DatabaseObjectExtensions
    {
        /// <summary>
        /// The method returns a db mediator object instance using the target as the orginal value.
        /// </summary>
        /// <typeparam name="T">Type parameter of the target for this extension method.</typeparam>
        /// <param name="target">Target value for this extension method.</param>
        /// <returns>
        /// Returns a new instance of <see cref="DbMediator"/>.
        /// </returns>
        public static DbMediator Db<T>(this T target)
        {
            return new DbMediator((object)target);
        }

        /// <summary>
        /// Returns <see cref="DBNull"/> for a <c>null</c> value, or the value of the db mediator itself.
        /// </summary>
        /// <param name="target">Target value for this extension method.</param>
        /// <returns>
        /// Returns either <see cref="DBNull"/> if <paramref name="target"/> or <see cref="DbMediator.Value"/> is null, otherwise the value of the db mediator itself.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
        public static object Value(this DbMediator target)
        {
            if (target == null || target.Value == null)
                return DBNull.Value;

            return target.Value;
        }

        /// <summary>
        /// The method checks whether the value is <c>null</c>.
        /// </summary>
        /// <param name="target">The target value to check.</param>
        /// <returns>
        /// Returns <c>true</c> if <paramref name="target"/> is either <c>null</c> or if the original value of the db mediator is <c>null</c> or <see cref="System.DBNull"/>, otherwise <c>false</c>.
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
        /// <para>
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>. If the value is
        /// a non-negative integer number, a new <see cref="DateTime"/> is created, using the numeric value as <see cref="DateTime.Ticks"/> for the date time.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
        public static DateTime ToDateTime(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToDateTime(provider);
        }

#if FW35
        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="TimeSpan.Parse"/> as there is no
        /// <c>System.Convert.ToTimeSpan</c>. If the value is an integer value, a new <see cref="TimeSpan"/> is created using the numeric value
        /// as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
#elif FW40
        /// <summary>
        /// The method performs a static cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="TimeSpan"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.TimeSpan.Parse(string)"/>. If the value is an integer
        /// value, a new <see cref="TimeSpan"/> is created using the numeric value as <see cref="TimeSpan.Ticks"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
#endif
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
        /// <summary>
        /// The method performs a static cast to <see cref="Decimal"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="Decimal"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.TimeSpan.Parse(string, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
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
        /// The method uses the <see cref="GenericExtensions.StaticCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">The exception is thrown if the db mediators value is either <c>null</c> or <see cref="System.DBNull"/>.</exception>
        public static UInt64 ToUInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (target.IsNullOrDbNull)
                throw new ArgumentException("You can not perform a static type conversion on a db mediator value that is either null or DBNull.");

            return target.Value.ToUInt64(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Boolean}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Boolean}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Boolean? AsBoolean(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsBoolean(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Boolean}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Boolean}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToBoolean(object, IFormatProvider)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Boolean? AsBoolean(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsBoolean(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Byte}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Byte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Byte? AsByte(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsByte(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Byte}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Byte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToByte(object, IFormatProvider)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Byte? AsByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsByte(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{SByte}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{SByte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static SByte? AsSByte(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSByte(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{SByte}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{SByte}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSByte(object, IFormatProvider)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static SByte? AsSByte(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSByte(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Char}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Char}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Char? AsChar(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsChar(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Char}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToChar(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Char}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToChar(object, IFormatProvider)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Char? AsChar(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsChar(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{DateTime}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{DateTime}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.AsDateTime{T}(T, IFormatProvider)"/> method. If the <see cref="DbMediator.Value"/> property of <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static DateTime? AsDateTime(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDateTime(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{DateTime}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDateTime(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{DateTime}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.AsDateTime{T}(T, IFormatProvider)"/> method. If the <see cref="DbMediator.Value"/> property of <paramref name="target"/>
        /// is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static DateTime? AsDateTime(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDateTime(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{TimeSpan}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{TimeSpan}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.AsTimeSpan{T}(T)"/> method. If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/>
        /// <c>null</c> is returned.
        /// </remarks>
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
         /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{TimeSpan}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.TimeSpan.TryParse(string, IFormatProvider, out TimeSpan)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{TimeSpan}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.TimeSpan.TryParse(string, IFormatProvider, out TimeSpan)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static TimeSpan? AsTimeSpan(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsTimeSpan(provider);
        }
#endif

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Decimal}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Decimal}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Decimal? AsDecimal(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDecimal(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Decimal}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Decimal}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDecimal(object, IFormatProvider)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Decimal? AsDecimal(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDecimal(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Double}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Double}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Double? AsDouble(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDouble(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Double}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Double}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToDouble(object, IFormatProvider)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Double? AsDouble(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsDouble(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Single}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Single}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Single? AsSingle(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSingle(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Single}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Single}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToSingle(object, IFormatProvider)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Single? AsSingle(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsSingle(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int16}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int16? AsInt16(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt16(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int16}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt16(object, IFormatProvider)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int16? AsInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt16(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt16}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static UInt16? AsUInt16(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt16(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt16}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt16}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt16(object, IFormatProvider)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static UInt16? AsUInt16(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt16(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int32}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int32? AsInt32(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt32(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int32}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt32(object, IFormatProvider)"/>. If the
        /// <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int32? AsInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt32(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt32}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static UInt32? AsUInt32(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt32(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt32}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt32}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt32(object, IFormatProvider)"/>.
        /// If the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static UInt32? AsUInt32(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt32(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int64}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int64? AsInt64(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt64(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{Int64}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{Int64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToInt64(object, IFormatProvider)"/>. If the <see cref="DbMediator.Value"/>
        /// property of<paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static Int64? AsInt64(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsInt64(provider);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt64}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static UInt64? AsUInt64(this DbMediator target)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsUInt64(null);
        }

        /// <summary>
        /// The method performs a dynamic cast to <see cref="System.Nullable{UInt64}"/>.
        /// </summary>
        /// <param name="target">Target of the cast.</param>
        /// <param name="provider">The format provider used for the <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>.</param>
        /// <returns>
        /// Returns a <see cref="System.Nullable{UInt64}"/> value.
        /// </returns>
        /// <remarks>
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToUInt64(object, IFormatProvider)"/>. If
        /// the <see cref="DbMediator.Value"/> property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
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
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object)"/>. If the <see cref="DbMediator.Value"/>
        /// property of <paramref name="target"/> is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
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
        /// The method uses the <see cref="GenericExtensions.DynamicCast"/> extension method in combination with <see cref="System.Convert.ToString(object, IFormatProvider)"/>. If <paramref name="target"/>
        /// the <see cref="DbMediator.Value"/> property of is <see cref="DBNull.Value"/> <c>null</c> is returned.
        /// </remarks>
        public static string AsString(this DbMediator target, IFormatProvider provider)
        {
            if (target == null || target.IsNullOrDbNull)
                return null;

            return target.Value.AsString(provider);
        }
    }
}