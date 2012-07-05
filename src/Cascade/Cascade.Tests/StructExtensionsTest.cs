using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cascade.Tests
{
    [TestClass]
    public class StructExtensionsTest
    {
        [TestMethod]
        public void IfNotNull_Action()
        {
            int? target = null;
            int? result = null;

            Action<int?> callback = t => result = t;

            target.IfNotNull(callback);
            Assert.IsNull(result);

            target = -1;

            target.IfNotNull(callback);
            Assert.AreEqual(target, result);

            try
            {
                target.IfNotNull(null);
                target = null;
                target.IfNotNull(null);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IfNotNull_Func()
        {
            int? target = null;
            int? result = null;

            Func<int?, int?> callback = t => { if (t.HasValue) return t + 1; else return null; };

            result = target.IfNotNull(callback);
            Assert.IsNull(result);

            target = 0;

            result = target.IfNotNull(callback);
            Assert.AreEqual(target + 1, result);

            callback = null;

            result = target.IfNotNull(callback);
            Assert.IsNull(result);

            target = null;
            result = 0;

            result = target.IfNotNull(callback);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNull_Action()
        {
            int? target = null;
            int? result = null;

            Action callback = () => result = 0;

            target.IfNull(callback);
            Assert.AreEqual(0, result);

            target = 1;
            result = null;

            target.IfNull(callback);
            Assert.IsNull(result);

            try
            {
                target.IfNull(null);
                target = null;
                target.IfNull(null);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IfNull_Func()
        {
            int? target = null;
            int? result = null;

            Func<int?> callback = () => { return 1; };

            result = target.IfNull(callback);
            Assert.AreEqual(1, result);

            result = null;
            target = 0;

            target.IfNull(callback);
            Assert.IsNull(result);

            callback = null;

            result = target.IfNull(callback);
            Assert.IsNull(result);

            target = null;
            result = 0;

            result = target.IfNull(callback);
            Assert.IsNull(result);
        }
    }
}
