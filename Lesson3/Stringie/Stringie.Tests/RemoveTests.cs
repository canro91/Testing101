using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stringie;
using System.Collections.Generic;

namespace StringieTests
{
    [TestClass]
    public class Remove
    {
        [TestMethod]
        public void Remove1()
        {
            string transformed = "Some string".Remove();

            Assert.AreEqual(0, transformed.Length);
        }

        [TestMethod]
        public void RemoveNull1()
        {
            string nullString = null;
            string transformed = nullString.Remove("Anything");

            Assert.IsNull(transformed);
        }

        [TestMethod]
        public void RemoveNull2()
        {
            string nullString = null;
            string transformed = nullString.Remove(null);

            Assert.IsNull(transformed);
        }

        [TestMethod]
        public void RemoveEmptyString()
        {
            string transformed = string.Empty.Remove("Something");

            Assert.AreEqual(0, transformed.Length);
        }

        [TestMethod]
        public void RemoveNull3()
        {
            string transformed = "Anything".Remove(null);

            Assert.AreEqual("Anything", transformed);
        }

        [TestMethod]
        public void Remove2()
        {
            string transformed = "Anything".Remove("Something");

            Assert.AreEqual("Anything", transformed);
        }

        [DataTestMethod]
        [DataRow("TeSt")]
        [DataRow("tEsT")]
        public void RemoveIgnoringCase(string remove)
        {
            string transformed = "TEST string will be removed".Remove(remove).IgnoringCase();

            Assert.AreEqual(" string will be removed", transformed);
        }

        [DataTestMethod]
        [DataRow("TEST")]
        [DataRow("TeSt")]
        public void RemoveIgnoringCase2(string remove)
        {
            string transformed = "TEST string will be removed. This TEST won't".Remove(remove).IgnoringCase();

            Assert.AreEqual(" string will be removed. This TEST won't", transformed);
        }
    }
}