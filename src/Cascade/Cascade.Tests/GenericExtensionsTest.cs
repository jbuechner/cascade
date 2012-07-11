using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cascade.Tests
{
    [TestClass]
    public class GenericExtensionsTest
    {
        [TestMethod]
        public void Invoke_Action()
        {
            int? value = 0;
            int callCounter = 0;

            value.Invoke(
                t =>
                {
                    t++;
                    Assert.AreEqual(1, t);
                    callCounter++;
                },
                t =>
                {
                    t += 2;
                    Assert.AreEqual(2, t);
                    callCounter++;
                }
            );

            Assert.AreEqual(2, callCounter);

            try
            {
                value.Invoke();
                value = null;
                value.Invoke();
                value.Invoke(t => { new object(); });
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Invoke_Func()
        {
            int? value = 0;
            int callCounter = 0;

            value = value.Invoke(
                t =>
                {
                    t++;
                    Assert.AreEqual(1, t);
                    callCounter++;
                    return t;
                },
                t =>
                {
                    t += 2;
                    Assert.AreEqual(3, t);
                    callCounter++;
                    return t;
                },
                t =>
                {
                    t -= 10;
                    Assert.AreEqual(-7, t);
                    callCounter++;
                    return t - 3;
                }
            );

            Assert.AreEqual(-10, value);

            Assert.AreEqual(3, callCounter);

            try
            {
                value.Invoke();
                value = null;
                value.Invoke();
                value.Invoke(t => { return t; });
            }
            catch
            {
            }
        }

        [TestMethod]
        public void GetValueOrNew()
        {
            object expected = new object();
            object target = expected;
            object result;

            Assert.AreSame(expected, target.GetValueOrNew());

            target = null;
            result = target.GetValueOrNew();
            Assert.IsNotNull(result);
            Assert.AreNotSame(expected, result);
        }

        [TestMethod]
        public void GetValueOrDefault_Object()
        {
            object target = null;
            object defaultValue = new object();

            object result = target.GetValueOrDefault(defaultValue);

            Assert.AreSame(defaultValue, result);

            target = new object();

            result = target.GetValueOrDefault(defaultValue);

            Assert.AreSame(target, result);

            defaultValue = null;

            result = target.GetValueOrDefault(defaultValue);
            Assert.AreSame(target, result);

            result = new object();
            defaultValue = new object();
            target = null;

            result = target.GetValueOrDefault(defaultValue);
            Assert.AreSame(defaultValue, result);
        }

        [TestMethod]
        public void GetValueOrDefault_Generic()
        {
            int? target = null;
            object defaultValue = new object();

            object result = target.GetValueOrDefault(defaultValue);

            Assert.AreSame(defaultValue, result);

            target = 1;

            result = target.GetValueOrDefault(defaultValue);

            Assert.AreEqual(1, result);

            defaultValue = null;

            result = target.GetValueOrDefault(defaultValue);
            Assert.AreEqual(target, result);

            result = new object();
            defaultValue = new object();
            target = null;

            result = target.GetValueOrDefault(defaultValue);
            Assert.AreEqual(defaultValue, result);
        }

        [TestMethod]
        public void IfNotNull_Action()
        {
            object target = null;
            object result = null;

            Action<object> callback = t => result = t;

            target.IfNotNull(callback);
            Assert.IsNull(result);

            target = new object();
            
            target.IfNotNull(callback);
            Assert.AreSame(target, result);

            try
            {
                target.IfNotNull((Action<object>)null);
                target = null;
                target.IfNotNull((Action<object>)null);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IfNotNull_Func()
        {
            object target = null;
            object result = null;

            Func<object, object> callback = t => { return t; };

            target.IfNotNull(callback);

            result = target.IfNotNull(callback);
            Assert.IsNull(result);

            target = new object();

            result = target.IfNotNull(callback);
            Assert.AreSame(target, result);

            result = new object();
            callback = null;

            result = target.IfNotNull(callback);
            Assert.IsNull(result);

            result = new object();
            target = null;

            result = target.IfNotNull(callback);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNull_Action()
        {
            object target = null;
            object result = null;

            Action callback = () => result = new object();

            target.IfNull(callback);
            Assert.IsNotNull(result);

            result = null;
            target = new object();

            target.IfNull(callback);
            Assert.IsNull(result);

            callback = null;

            try
            {
                target.IfNull(callback);
                target = null;
                target.IfNull(callback);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IfNull_Func()
        {
            object target = null;
            object result = null;

            Func<object> callback = () => { return new object(); };

            result = target.IfNull(callback);
            Assert.IsNotNull(result);

            result = null;
            target = new object();

            result = target.IfNull(callback);
            Assert.IsNull(result);

            result = new object();
            callback = null;

            result = target.IfNull(callback);
            Assert.IsNull(result);

            result = new object();
            target = null;

            result = target.IfNull(callback);
            Assert.IsNull(result);
        }
    }
}
