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
        [Flags]
        enum SmallSignedEnum : sbyte
        {
            One = 64,
            Two = 32,
            Three = 16,
            All = One | Two | Three
        }

        [Flags]
        enum LargeSignedEnum : long
        {
            One = 4611686018427387904,
            Two = 2305843009213693952,
            Three = 1152921504606846976,
            All = One | Two | Three
        }

        [Flags]
        enum SmallUnsignedEnum : byte
        {
            One = 182,
            Two = 64,
            Three = 32,
            All = One | Two | Three
        }

        [Flags]
        enum LargeUnsignedEnum : ulong
        {
            One = 9223372036854775808,
            Two = 4611686018427387904,
            Three = 2305843009213693952,
            All = One | Two | Three
        }

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

        [TestMethod]
        public void HasFlag_SignedTypes()
        {
            SmallSignedEnum sse = SmallSignedEnum.One;
            LargeSignedEnum lse = LargeSignedEnum.One;

            Assert.IsTrue(sse == (sse | SmallSignedEnum.One));
            Assert.IsFalse(sse == (sse | SmallSignedEnum.Two));
            Assert.IsTrue(lse == (lse | LargeSignedEnum.One));
            Assert.IsFalse(lse == (lse | LargeSignedEnum.Two));

            Assert.IsTrue(sse.HasFlag(SmallSignedEnum.One));
            Assert.IsFalse(sse.HasFlag(SmallSignedEnum.Two));
            Assert.IsTrue(lse.HasFlag(LargeSignedEnum.One));
            Assert.IsFalse(lse.HasFlag(LargeSignedEnum.Two));

            sse |= SmallSignedEnum.Three;
            lse |= LargeSignedEnum.Three;

            Assert.IsTrue(sse.HasFlag(SmallSignedEnum.One));
            Assert.IsTrue(sse.HasFlag(SmallSignedEnum.Three));
            Assert.IsFalse(sse.HasFlag(SmallSignedEnum.Two));
            Assert.IsTrue(lse.HasFlag(LargeSignedEnum.One));
            Assert.IsTrue(lse.HasFlag(LargeSignedEnum.Three));
            Assert.IsFalse(lse.HasFlag(LargeSignedEnum.Two));

            Assert.IsTrue(((int)sse).HasFlag(64));
            Assert.IsFalse(((int)sse).HasFlag(32));
            Assert.IsTrue(((long)lse).HasFlag(4611686018427387904));
            Assert.IsFalse(((long)lse).HasFlag(2305843009213693952));

            long n = 4611686018427387904 | 2305843009213693952;

            Assert.IsTrue(n == (n | 2305843009213693952));
            Assert.IsTrue(n.HasFlag(2305843009213693952));
        }

        [TestMethod]
        public void HasFlag_UnsignedTypes()
        {
            SmallUnsignedEnum sse = SmallUnsignedEnum.One;
            LargeUnsignedEnum lse = LargeUnsignedEnum.One;

            Assert.IsTrue(sse == (sse | SmallUnsignedEnum.One));
            Assert.IsFalse(sse == (sse | SmallUnsignedEnum.Two));
            Assert.IsTrue(lse == (lse | LargeUnsignedEnum.One));
            Assert.IsFalse(lse == (lse | LargeUnsignedEnum.Two));

            Assert.IsTrue(sse.HasFlag(SmallUnsignedEnum.One));
            Assert.IsFalse(sse.HasFlag(SmallUnsignedEnum.Two));
            Assert.IsTrue(lse.HasFlag(LargeUnsignedEnum.One));
            Assert.IsFalse(lse.HasFlag(LargeUnsignedEnum.Two));

            sse |= SmallUnsignedEnum.Three;
            lse |= LargeUnsignedEnum.Three;

            Assert.IsTrue(sse.HasFlag(SmallUnsignedEnum.One));
            Assert.IsTrue(sse.HasFlag(SmallUnsignedEnum.Three));
            Assert.IsFalse(sse.HasFlag(SmallUnsignedEnum.Two));
            Assert.IsTrue(lse.HasFlag(LargeUnsignedEnum.One));
            Assert.IsTrue(lse.HasFlag(LargeUnsignedEnum.Three));
            Assert.IsFalse(lse.HasFlag(LargeUnsignedEnum.Two));

            Assert.IsTrue(((uint)sse).HasFlag((uint)128));
            Assert.IsFalse(((uint)sse).HasFlag((uint)64));
            Assert.IsTrue(((ulong)lse).HasFlag((ulong)9223372036854775808));
            Assert.IsFalse(((ulong)lse).HasFlag((ulong)4611686018427387904));

            ulong n = 9223372036854775808 | 4611686018427387904;

            Assert.IsTrue(n == (n | 4611686018427387904));
            Assert.IsTrue(n.HasFlag((ulong)4611686018427387904));
        }
    }
}
