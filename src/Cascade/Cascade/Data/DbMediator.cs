using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade.Data
{
    /// <summary>
    /// The <I>DbMediator</I> class is an intermediate product of the database object extensions. It is used to store the original value
    /// of a extension method call, as well as additional information.
    /// </summary>
    public class DbMediator
    {
        /// <summary>
        /// Gets the original value.
        /// </summary>
        public object Value { get; private set; }
        /// <summary>
        /// Gets a value whether the value is <see cref="System.DBNull.Value"/> or not.
        /// </summary>
        public bool IsDbNull { get; private set; }
        /// <summary>
        /// Gets a value whether the value is <c>null</c> or not.
        /// </summary>
        public bool IsNull { get; private set; }

        /// <summary>
        /// Gets a value whether the value is <c>null</c> or not or <see cref="System.DBNull.Value"/> or not.
        /// </summary>
        public bool IsNullOrDbNull { get; private set; }

        /// <summary>
        /// Creates a new db mediator instance.
        /// </summary>
        /// <param name="value">Original value.</param>
        public DbMediator(object value)
        {
            this.Value = value;

            if (value == null)
                this.IsNull = true;
            else
                this.IsDbNull = Convert.IsDBNull(value);

            this.IsNullOrDbNull = this.IsNull || this.IsDbNull;
        }
    }
}
