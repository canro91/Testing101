using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stringie;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Remove
    {
        [TestMethod]
        public void Remove1()
        {
            string transformed = "Some string".Remove();
            if (string.IsNullOrEmpty(transformed))
            {
                throw new Exception("This test should fail");
            }
        }

        [TestMethod]
        public void RemoveNullString()
        {
            string nullString = null;
            string transformed = nullString.Remove("Anything");
            if (!string.IsNullOrEmpty(transformed))
            {
                throw new Exception("This test should fail");
            }
        }

        [TestMethod]
        public void RemoveNull()
        {
            string nullString = null;
            string transformed = nullString.Remove(null);
            Assert.IsNull(transformed);
        }

        [TestMethod]
        public void RemoveTextFromEmptyString()
        {
            string transformed = string.Empty.Remove("Something");
            Assert.IsTrue(transformed == string.Empty);
        }

        [TestMethod]
        public void RemoveNull2()
        {
            string transformed = "Anything".Remove(null);

            Assert.AreEqual("Anything", transformed);
        }

        [TestMethod]
        public void RemoveEmptyText()
        {
            Assert.AreEqual("", "Anything".Remove(string.Empty));
        }

        [TestMethod]
        public void RemoveNonExistingText()
        {
            string transformed = "Anything".Remove("Something");
            Assert.AreEqual("Anything", transformed);
        }

        [TestMethod]
        public void RemoveTextIgnoringCase()
        {
            string transformed = "TEST string will be removed".Remove("TeSt").IgnoringCase();
            Assert.AreEqual(" string will be removed", transformed);

            transformed = "TEST string will be removed".Remove("tEsT").IgnoringCase();
            Assert.AreEqual(" string will be removed", transformed);
        }

        [TestMethod]
        public void RemoveTextIgnoringCaseWithMultipleValues()
        {
            string transformed = "TEST string will be removed. This TEST won't".Remove("TEST").IgnoringCase();
            Assert.AreEqual(" string will be removed. This TEST won't", transformed);

            transformed = "TEST string will be removed. This TEST won't".Remove("TeSt").IgnoringCase();
            Assert.AreEqual(" string will be removed. This TEST won't", transformed);
        }

        [TestMethod]
        public void Insert1()
        {
            string transformed = "<-- TEST string will be inserted here".Insert("TEST");
            Assert.AreEqual("TEST<-- TEST string will be inserted here", transformed);

            transformed = "<-- TEST string will be inserted here".Insert("TEST").To(The.Beginning);
            Assert.AreEqual("TEST<-- TEST string will be inserted here", transformed);
        }

        [TestMethod]
        public void Insert3()
        {
            string transformed = "TEST string will be inserted here -->".Insert("TEST").To(The.End);
            Assert.AreEqual("TEST string will be inserted here -->TEST", transformed);
        }

        [TestMethod]
        public void IsNullStringEmptyOrWhiteSpace()
        {
            string str = null;
            bool isEmptyOrWhiteSpace = str.IsEmpty().OrWhiteSpace();
            Assert.AreEqual(string.IsNullOrEmpty(str), isEmptyOrWhiteSpace);
        }

        [TestMethod]
        public void IsEmptyStringEmptyOrWhiteSpace()
        {
            bool isEmptyOrWhiteSpace = string.Empty.IsEmpty().OrWhiteSpace();
            Assert.AreEqual(string.IsNullOrEmpty(string.Empty), isEmptyOrWhiteSpace);
        }
    }
}