using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cascade.Data
{
    public class DbMediator
    {
        public object Value { get; private set; }
        public bool IsDbNull { get; private set; }
        public bool IsNull { get; private set; }

        public bool IsNullOrDbNull { get; private set; }

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
