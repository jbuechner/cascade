using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;

namespace Cascade.Tests
{
    [TestClass]
    public class ObjectExtensionsTest
    {
        class Animal
        {
        }

        class Cat : Animal
        {
        }

        class Dog : Animal
        {
        }

        [TestInitialize]
        public void Init()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void To()
        {
            Cat myCat = new Cat();
            Animal myAnimal = myCat;
            Dog myDog = null;
            Cat lostCat = null;

            lostCat = myAnimal.To<Cat>();
            Assert.AreSame(myCat, lostCat);

            myAnimal = null;
            lostCat = myAnimal.To<Cat>();
            Assert.IsNull(lostCat);

            try
            {
                myDog = myAnimal.To<Dog>();
                Assert.Fail();
            }
            catch
            {
            }
        }

        [TestMethod]
        public void As()
        {
            Cat myCat = new Cat();
            Animal myAnimal = myCat;
            Dog myDog = new Dog(); ;
            Cat lostCat = null;

            lostCat = myAnimal.As<Cat>();
            Assert.AreSame(myCat, lostCat);

            myAnimal = null;
            lostCat = myAnimal.As<Cat>();
            Assert.IsNull(lostCat);

            try
            {
                myDog = myAnimal.As<Dog>();
                Assert.IsNull(myDog);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void IsNull()
        {
            object value = null;

            Assert.IsTrue(value.IsNull());
            value = new object();
            Assert.IsFalse(value.IsNull());
        }

        [TestMethod]
        public void StaticCast()
        {
            object value = (int)10;
            int? result = null;

            result = value.StaticCast(t => (int)t);
            Assert.AreEqual(10, result);

            try
            {
                value.StaticCast(t => (string)t);
                value.StaticCast<int>(null);
                value = null;
                value.StaticCast<int>(null);
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            try
            {
                value.StaticCast<int>(null);
            }
            catch
            {
                Assert.Fail();
            }

            value = null;

            try
            {
                value.StaticCast<int>(null);
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void DynamicCast()
        {
            object value = (int)10;
            int? result = null;

            Func<object, int?> castCallback = t => { if (t is int) return (int)t; else return null; };

            result = value.DynamicCast<int?>(castCallback);
            Assert.AreEqual(10, result);

            result = value.DynamicCast<int?>(null);
            Assert.AreEqual(10, result);

            value = (long)10;
            result = value.DynamicCast<int?>(null);
            Assert.IsNull(result);

            value = null;
            result = 2;

            result = value.DynamicCast<int?>(castCallback);
            Assert.IsNull(result);

            result = 2;
            result = value.DynamicCast<int?>(null);
            Assert.IsNull(result);

        }

        [TestMethod]
        public void ToBoolean()
        {
            object value = 0;
            bool result;

            result = value.ToBoolean();
            Assert.IsFalse(result);

            value = 1;
            result = value.ToBoolean();
            Assert.IsTrue(result);

            value = false;
            result = value.ToBoolean();
            Assert.IsFalse(result);

            value = true;
            result = value.ToBoolean();
            Assert.IsTrue(result);

            value = "0";

            try
            {
                value.ToBoolean();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = bool.TrueString;

            try
            {
                Assert.AreEqual(true, value.ToBoolean());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = null;

            try
            {
                value.ToBoolean();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToByte()
        {
            object value = 10;
            byte result;

            result = value.ToByte();
            Assert.AreEqual(10, result);

            value = -10;

            try
            {
                value.ToByte();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = "10";

            try
            {
                Assert.AreEqual(10, value.ToByte());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = null;

            try
            {
                value.ToByte();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToSByte()
        {
            object value = 10;
            sbyte result;

            result = value.ToSByte();
            Assert.AreEqual(10, result);

            value = -10;

            result = value.ToSByte();
            Assert.AreEqual(-10, result);

            value = "10";

            try
            {
                Assert.AreEqual(10, value.ToSByte());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10";

            try
            {
                Assert.AreEqual(-10, value.ToSByte());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = null;

            try
            {
                value.ToSByte();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToChar()
        {
            object value = ' ';
            char result;

            result = value.ToChar();
            Assert.AreEqual(' ', result);

            value = " ";

            try
            {
                Assert.AreEqual(' ', value.ToChar());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "  ";

            try
            {
                value.ToChar();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToChar();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToDateTime()
        {
            object value;
            DateTime result;
            DateTime expected = DateTime.Now;
            value = expected;

            result = value.ToDateTime();
            Assert.AreEqual(expected, result);

            value = "2011-02-01";

            try
            {
                Assert.AreEqual(new DateTime(2011, 2, 1), value.ToDateTime());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "2011+02-01";

            try
            {
                value.ToDateTime();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToDateTime();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToTimeSpan()
        {
            object value;
            TimeSpan result;
            TimeSpan expected = new TimeSpan(5, 3, 2, 1, 125);
            value = expected;

            result = value.ToTimeSpan();
            Assert.AreEqual(expected, result);

            value = "10:20:30.091";

            try
            {
                Assert.AreEqual(new TimeSpan(0, 10, 20, 30, 91), value.ToTimeSpan());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10+20:30.091";

            try
            {
                value.ToTimeSpan();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToTimeSpan();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToDecimal()
        {
            object value = decimal.MaxValue;
            decimal result;

            result = value.ToDecimal();
            Assert.AreEqual(decimal.MaxValue, result);

            value = "10098.019887";

            try
            {
                Assert.AreEqual((decimal)10098.019887, value.ToDecimal());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098,019887";

            try
            {
                Assert.AreEqual((decimal)10098019887, value.ToDecimal());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098+019887";

            try
            {
                value.ToDecimal();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToDecimal();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToDouble()
        {
            object value = double.MaxValue;
            double result;

            result = value.ToDouble();
            Assert.AreEqual(double.MaxValue, result);

            value = "10098.019887";

            try
            {
                Assert.AreEqual((double)10098.019887, value.ToDouble());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098,019887";

            try
            {
                Assert.AreEqual((double)10098019887, value.ToDouble());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098+019887";

            try
            {
                value.ToDouble();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToDouble();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToSingle()
        {
            object value = float.MaxValue;
            float result;

            result = value.ToSingle();
            Assert.AreEqual(float.MaxValue, result);

            value = "10098.019887";

            try
            {
                Assert.AreEqual((float)10098.019887, value.ToSingle());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098,019887";

            try
            {
                Assert.AreEqual((float)10098019887, value.ToSingle());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "10098+019887";

            try
            {
                value.ToSingle();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToSingle();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToInt16()
        {
            object value = short.MaxValue;
            short result;

            result = value.ToInt16();
            Assert.AreEqual(short.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((short)10098, value.ToInt16());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                Assert.AreEqual((short)-10098, value.ToInt16());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "1000098.123";

            try
            {
                value.ToInt16();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToInt16();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToUInt16()
        {
            object value = ushort.MaxValue;
            ushort result;

            result = value.ToUInt16();
            Assert.AreEqual(ushort.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((ushort)10098, value.ToUInt16());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                value.ToUInt16();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = "1000098.123";

            try
            {
                value.ToUInt16();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToUInt16();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToInt32()
        {
            object value = int.MaxValue;
            int result;

            result = value.ToInt32();
            Assert.AreEqual(int.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((int)10098, value.ToInt32());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                Assert.AreEqual((int)-10098, value.ToInt32());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "1000098.123";

            try
            {
                value.ToInt32();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToInt32();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToUInt32()
        {
            object value = uint.MaxValue;
            uint result;

            result = value.ToUInt32();
            Assert.AreEqual(uint.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((uint)10098, value.ToUInt32());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                value.ToUInt32();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = "1000098.123";

            try
            {
                value.ToUInt32();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToUInt32();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToInt64()
        {
            object value = long.MaxValue;
            long result;

            result = value.ToInt64();
            Assert.AreEqual(long.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((long)10098, value.ToInt64());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                Assert.AreEqual((long)-10098, value.ToInt64());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "1000098.123";

            try
            {
                value.ToInt64();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToInt64();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ToUInt64()
        {
            object value = ulong.MaxValue;
            ulong result;

            result = value.ToUInt64();
            Assert.AreEqual(ulong.MaxValue, result);

            value = "10098";

            try
            {
                Assert.AreEqual((ulong)10098, value.ToUInt64());
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
                Assert.Fail();
            }

            value = "-10098";

            try
            {
                value.ToUInt64();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = "1000098.123";

            try
            {
                value.ToUInt64();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }

            value = null;

            try
            {
                value.ToUInt64();
                Assert.Fail();
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void AsBoolean()
        {
            object value = null;
            Assert.IsNull(value.AsBoolean());
            value = true;
            Assert.AreEqual(true, value.AsBoolean());
            value = false;
            Assert.AreEqual(false, value.AsBoolean());
            Assert.AreEqual(true, (1).AsBoolean());
            Assert.AreEqual(false, (0).AsBoolean());
            Assert.AreEqual(true, (-1).AsBoolean());
            Assert.AreEqual(true, bool.TrueString.AsBoolean());
            Assert.AreEqual(false, bool.FalseString.AsBoolean());
            Assert.IsNull(" ".AsBoolean());
            Assert.AreEqual(true, (10.1).AsBoolean());
        }

        [TestMethod]
        public void AsByte()
        {
            Assert.IsNull(((object)null).AsByte());
            Assert.AreEqual(byte.MaxValue, ((object)byte.MaxValue).AsByte());
            Assert.AreEqual(byte.MinValue, ((object)byte.MinValue).AsByte());
            Assert.IsNull(" ".AsByte());
            Assert.AreEqual((byte)10, (10.1).AsByte());
            Assert.IsNull((256).AsByte());
            Assert.IsNull((-1).AsByte());
            Assert.AreEqual((byte)5, "5".AsByte());
        }

        [TestMethod]
        public void AsSByte()
        {
            Assert.IsNull(((object)null).AsSByte());
            Assert.AreEqual(sbyte.MaxValue, ((object)sbyte.MaxValue).AsSByte());
            Assert.AreEqual(sbyte.MinValue, ((object)sbyte.MinValue).AsSByte());
            Assert.IsNull(" ".AsSByte());
            Assert.AreEqual((sbyte)10, (10.1).AsSByte());
            Assert.IsNull((256).AsSByte());
            Assert.AreEqual((sbyte)5, "5".AsSByte());
        }

        [TestMethod]
        public void AsChar()
        {
            Assert.IsNull(((object)null).AsChar());
            Assert.AreEqual(' ', " ".AsChar());
            Assert.IsNull("  ".AsChar());
            Assert.AreEqual(' ', (32).AsChar());
            Assert.IsNull((32.1).AsChar());
            Assert.IsNull((-32).AsChar());
            Assert.IsNull((-32.1).AsChar());
        }

        [TestMethod]
        public void AsDateTime()
        {
            Assert.IsNull(((object)null).AsDateTime());
            Assert.AreEqual(new DateTime(2012, 02, 01), "2012-02-01".AsDateTime());
            Assert.AreEqual(new DateTime(2000, 02, 29), "29 Feb 2000".AsDateTime());
            Assert.IsNull("2000+02-01".AsDateTime());
        }

        [TestMethod]
        public void AsTimeSpan()
        {
            Assert.IsNull(((object)null).AsTimeSpan());
            Assert.AreEqual(new TimeSpan(10, 20, 30), "10:20:30".AsTimeSpan());
            Assert.AreEqual(new TimeSpan(1, 10, 20, 30, 91), "1.10:20:30.091".AsTimeSpan());
            Assert.IsNull("10+20:30".AsTimeSpan());
        }

        [TestMethod]
        public void AsDecimal()
        {
            Assert.IsNull(((object)null).AsDecimal());
            Assert.AreEqual(decimal.MaxValue, ((object)decimal.MaxValue).AsDecimal());
            Assert.AreEqual(decimal.MinValue, ((object)decimal.MinValue).AsDecimal());
            Assert.IsNull(" ".AsDecimal());
            Assert.AreEqual((decimal)10.1, (10.1).AsDecimal());
            Assert.AreEqual((decimal)101, "10,1".AsDecimal());
            Assert.AreEqual((decimal)5, "5".AsDecimal());
        }

        [TestMethod]
        public void AsDouble()
        {
            Assert.IsNull(((object)null).AsDouble());
            Assert.AreEqual(double.MaxValue, ((object)double.MaxValue).AsDouble());
            Assert.AreEqual(double.MinValue, ((object)double.MinValue).AsDouble());
            Assert.IsNull(" ".AsDouble());
            Assert.AreEqual((double)10.1, (10.1).AsDouble());
            Assert.AreEqual((double)101, "10,1".AsDouble());
            Assert.AreEqual((double)5, "5".AsDouble());
        }

        [TestMethod]
        public void AsSingle()
        {
            Assert.IsNull(((object)null).AsSingle());
            Assert.AreEqual(float.MaxValue, ((object)float.MaxValue).AsSingle());
            Assert.AreEqual(float.MinValue, ((object)float.MinValue).AsSingle());
            Assert.IsNull(" ".AsSingle());
            Assert.AreEqual((float)10.1, (10.1).AsSingle());
            Assert.AreEqual((float)101, "10,1".AsSingle());
            Assert.AreEqual((float)5, "5".AsSingle());
        }

        [TestMethod]
        public void AsInt16()
        {
            Assert.IsNull(((object)null).AsInt16());
            Assert.AreEqual(short.MaxValue, ((object)short.MaxValue).AsInt16());
            Assert.AreEqual(short.MinValue, ((object)short.MinValue).AsInt16());
            Assert.IsNull(" ".AsInt16());
            Assert.AreEqual((short)10, (10.1).AsInt16());
            Assert.IsNull((Int16.MaxValue + 1).AsInt16());
            Assert.AreEqual((short)5, "5".AsInt16());
        }

        [TestMethod]
        public void AsUInt16()
        {
            Assert.IsNull(((object)null).AsUInt16());
            Assert.AreEqual(ushort.MaxValue, ((object)ushort.MaxValue).AsUInt16());
            Assert.AreEqual(ushort.MinValue, ((object)ushort.MinValue).AsUInt16());
            Assert.IsNull(" ".AsUInt16());
            Assert.AreEqual((ushort)10, (10.1).AsUInt16());
            Assert.IsNull(((uint)ushort.MaxValue + 1).AsUInt16());
            Assert.IsNull((-1).AsUInt16());
            Assert.AreEqual((ushort)5, "5".AsUInt16());
        }

        [TestMethod]
        public void AsInt32()
        {
            Assert.IsNull(((object)null).AsInt32());
            Assert.AreEqual(int.MaxValue, ((object)int.MaxValue).AsInt32());
            Assert.AreEqual(int.MinValue, ((object)int.MinValue).AsInt32());
            Assert.IsNull(" ".AsInt32());
            Assert.AreEqual((int)10, (10.1).AsInt32());
            Assert.IsNull(((long)(Int32.MaxValue) + 1).AsInt32());
            Assert.AreEqual((int)5, "5".AsInt32());
        }

        [TestMethod]
        public void AsUInt32()
        {
            Assert.IsNull(((object)null).AsUInt32());
            Assert.AreEqual(uint.MaxValue, ((object)uint.MaxValue).AsUInt32());
            Assert.AreEqual(uint.MinValue, ((object)uint.MinValue).AsUInt32());
            Assert.IsNull(" ".AsUInt32());
            Assert.AreEqual((uint)10, (10.1).AsUInt32());
            Assert.IsNull(((ulong)uint.MaxValue + 1).AsUInt32());
            Assert.IsNull((-1).AsUInt32());
            Assert.AreEqual((uint)5, "5".AsUInt32());
        }

        [TestMethod]
        public void AsInt64()
        {
            Assert.IsNull(((object)null).AsInt64());
            Assert.AreEqual(long.MaxValue, ((object)long.MaxValue).AsInt64());
            Assert.AreEqual(long.MinValue, ((object)long.MinValue).AsInt64());
            Assert.IsNull(" ".AsInt64());
            Assert.AreEqual((long)10, (10.1).AsInt64());
            Assert.AreEqual((long)5, "5".AsInt64());
        }

        [TestMethod]
        public void AsUInt64()
        {
            Assert.IsNull(((object)null).AsUInt64());
            Assert.AreEqual(ulong.MaxValue, ((object)ulong.MaxValue).AsUInt64());
            Assert.AreEqual(ulong.MinValue, ((object)ulong.MinValue).AsUInt64());
            Assert.IsNull(" ".AsUInt64());
            Assert.AreEqual((ulong)10, (10.1).AsUInt64());
            Assert.IsNull((-1).AsUInt64());
            Assert.AreEqual((ulong)5, "5".AsUInt64());
        }

        [TestMethod]
        public void AsString()
        {
            Assert.IsNull(((object)null).AsString());
            Assert.AreEqual(" ", ' '.AsString());
            Assert.AreEqual("1", (1).AsString());
            Assert.AreEqual("-1", (-1).AsString());
            Assert.AreEqual(bool.TrueString, (true).AsString());
            Assert.AreEqual(new DateTime(2012, 12, 1).ToString(), new DateTime(2012, 12, 1).AsString());
        }
    }
}