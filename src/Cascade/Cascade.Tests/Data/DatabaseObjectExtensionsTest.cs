using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cascade;
using Cascade.Data;

namespace Cascade.Tests.Data
{
    [TestClass]
    public class DatabaseObjectExtensionsTest
    {
        [TestMethod]
        public void DbIsNull()
        {
            Assert.IsTrue(((object)null).DbIsNull());
            Assert.IsTrue(DBNull.Value.DbIsNull());
            Assert.IsFalse(new object().DbIsNull());
        }

        [TestMethod]
        public void DbAsBoolean()
        {
            Assert.AreEqual(true, (1).DbAsBoolean());
            Assert.IsNull(((object)null).DbAsBoolean());
            Assert.IsNull(DBNull.Value.DbAsBoolean());
        }

        [TestMethod]
        public void DbAsByte()
        {
            Assert.AreEqual((byte)1, (1).DbAsByte());
            Assert.IsNull(((object)null).DbAsByte());
            Assert.IsNull(DBNull.Value.DbAsByte());
        }

        [TestMethod]
        public void DbAsSByte()
        {
            Assert.AreEqual((sbyte)1, (1).DbAsSByte());
            Assert.IsNull(((object)null).DbAsSByte());
            Assert.IsNull(DBNull.Value.DbAsByte());
        }

        [TestMethod]
        public void DbAsChar()
        {
            Assert.AreEqual((char)1, (1).DbAsChar());
            Assert.IsNull(((object)null).DbAsChar());
            Assert.IsNull(DBNull.Value.DbAsChar());
        }

        [TestMethod]
        public void DbAsDateTime()
        {
            Assert.AreEqual(new DateTime(1), (1).DbAsDateTime());
            Assert.IsNull(((object)null).DbAsDateTime());
            Assert.IsNull(DBNull.Value.DbAsDateTime());
        }

        [TestMethod]
        public void DbAsTimeSpan()
        {
            Assert.AreEqual(new TimeSpan(1), (1).DbAsTimeSpan());
            Assert.IsNull(((object)null).DbAsTimeSpan());
            Assert.IsNull(DBNull.Value.DbAsTimeSpan());
        }

        [TestMethod]
        public void DbAsDecimal()
        {
            Assert.AreEqual((Decimal)1, (1).DbAsDecimal());
            Assert.IsNull(((object)null).DbAsDecimal());
            Assert.IsNull(DBNull.Value.DbAsDecimal());
        }

        [TestMethod]
        public void DbAsDouble()
        {
            Assert.AreEqual((Double)1, (1).DbAsDouble());
            Assert.IsNull(((object)null).DbAsDouble());
            Assert.IsNull(DBNull.Value.DbAsDouble());
        }

        [TestMethod]
        public void DbAsSingle()
        {
            Assert.AreEqual((Single)1, (1).DbAsSingle());
            Assert.IsNull(((object)null).DbAsSingle());
            Assert.IsNull(DBNull.Value.DbAsSingle());
        }

        [TestMethod]
        public void DbAsInt16()
        {
            Assert.AreEqual((Int16)1, (1).DbAsInt16());
            Assert.IsNull(((object)null).DbAsInt16());
            Assert.IsNull(DBNull.Value.DbAsInt16());
        }

        [TestMethod]
        public void DbAsUInt16()
        {
            Assert.AreEqual((UInt16)1, (1).DbAsUInt16());
            Assert.IsNull(((object)null).DbAsUInt16());
            Assert.IsNull(DBNull.Value.DbAsUInt16());
        }

        [TestMethod]
        public void DbAsInt32()
        {
            Assert.AreEqual((Int32)1, (1).DbAsInt32());
            Assert.IsNull(((object)null).DbAsInt32());
            Assert.IsNull(DBNull.Value.DbAsInt32());
        }

        [TestMethod]
        public void DbAsUInt32()
        {
            Assert.AreEqual((UInt32)1, (1).DbAsUInt32());
            Assert.IsNull(((object)null).DbAsUInt32());
            Assert.IsNull(DBNull.Value.DbAsUInt32());
        }

        [TestMethod]
        public void DbAsInt64()
        {
            Assert.AreEqual((Int64)1, (1).DbAsInt64());
            Assert.IsNull(((object)null).DbAsInt64());
            Assert.IsNull(DBNull.Value.DbAsInt64());
        }

        [TestMethod]
        public void DbAsUInt64()
        {
            Assert.AreEqual((UInt64)1, (1).DbAsUInt64());
            Assert.IsNull(((object)null).DbAsUInt64());
            Assert.IsNull(DBNull.Value.DbAsUInt64());
        }
    }
}