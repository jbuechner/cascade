using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cascade.Tests
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ForEach_Object()
        {
            object[] values = new object[] { 1, 2, 3 };
            int sum = 0;

            Action<object> callback = t => sum += (int)t;

            values.ForEach(callback);
            Assert.AreEqual(6, sum);

            callback = null;

            try
            {
                values.ForEach(callback);
                values = null;
                values.ForEach(callback);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ForEach_Generic()
        {
            int[] values = new int[] { 1, 2, 3 };
            int sum = 0;

            Action<int> callback = t => sum += t;

            values.ForEach(callback);
            Assert.AreEqual(6, sum);

            try
            {
                values.ForEach(callback);
                values = null;
                values.ForEach(callback);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Cast()
        {
            double[] values = new double[] { 1.1, 2.2, 3.3, 9.9 };
            int[] result;
            IEnumerable<int> resultEnumeration;

            Converter<double, int> castCallback = c => { return (int)c; };

            result = values.Cast(castCallback).ToArray();

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(9, result[3]);

            values = null;

            resultEnumeration = values.Cast(castCallback);

            Assert.IsNotNull(resultEnumeration);
            Assert.AreEqual(0, resultEnumeration.Count());

            resultEnumeration = values.Cast((Converter<double, int>)null);

            Assert.IsNotNull(resultEnumeration);
            Assert.AreEqual(0, resultEnumeration.Count());
        }
    }
}
