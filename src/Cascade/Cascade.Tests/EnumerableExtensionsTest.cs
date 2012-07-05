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
    }
}
