using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cascade.Tests
{
    [TestClass]
    public class DictionaryExtensionsTest
    {
        [TestMethod]
        public void Get()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string key = "a";
            string value = "myValue";
            string result = null;

            result = dictionary.Get(key);
            Assert.IsNull(result);

            dictionary.Add(key, value);
            result = dictionary.Get(key);
            Assert.AreEqual(value, result);

            dictionary = null;
            result = dictionary.Get(key);
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Get_Callback()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string key = "a";
            string value = "myValue";
            string result = null;
            Func<string> valueNeededCallback = () => { return value; };

            result = dictionary.Get(key, null);
            Assert.IsNull(result);

            result = dictionary.Get(key, valueNeededCallback);
            Assert.AreEqual(value, result);
            Assert.IsTrue(dictionary.ContainsKey(key));
            Assert.AreEqual(value, dictionary[key]);

            dictionary = null;
            result = dictionary.Get(key, valueNeededCallback);
            Assert.IsNull(result);
        }
    }
}
