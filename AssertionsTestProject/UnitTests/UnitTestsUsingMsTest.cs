using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;
using StringAssert = Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert;

namespace AssertionsTestProject.UnitTests
{
    [TestClass]
    public class UnitTestsUsingMsTest
    {
        [TestMethod]
        public void IsStringContainsSubstring()
        {
            string stringValue = "programming language";
            string substring = "program";

            StringAssert.Contains(stringValue.ToUpper(), substring.ToUpper());
        }

        [TestMethod]
        public void IsValidEmail()
        {
            string email = "sasha@mail.ru";
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            StringAssert.Matches(email, emailRegex);
        }

        [TestMethod]
        public void IsObjectsReferToSameObject()
        {
            object obj1 = new object();
            object obj2 = obj1;
            object obj3 = obj1;

            Assert.AreSame(obj2, obj3);
        }

        [DataTestMethod]
        [DataRow(2, 3, 6)]
        [DataRow(1, 0, 0)]
        [DataRow(-4, 6, -24)]
        [DataRow(-4, -6, 24)]
        public void IsConditionTrue(int value1, int value2, int result)
        {
            Assert.IsTrue(value1 * value2 == result);
        }

        [DataTestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(1, 0, 1)]
        [DataRow(-4, 6, 24)]
        [DataRow(-4, -6, -24)]
        public void IsConditionFalse(int value1, int value2, int result)
        {
            Assert.IsFalse(value1 * value2 == result);
        }

        [TestMethod]
        public void IsCollectionsEqual()
        {
            List<int> list1 = new List<int>() {1, 2, 3, 4};
            List<int> list2 = new List<int>() {1, 2, 3, 4};

            CollectionAssert.AreEqual(list1, list2);
        }

        [DataTestMethod]
        [DataRow(3)]
        [DataRow(2)]
        [DataRow(1)]
        public void IsCollectionContainsEl(int elem)
        {
            List<int> list1 = new List<int>() {1, 2, 3, 4};

            CollectionAssert.Contains(list1, elem);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void IsMethodThrowsException()
        {
            object obj = "some string";
            int num = (int) obj;
        }
    }
}