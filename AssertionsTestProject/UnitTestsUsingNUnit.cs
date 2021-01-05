using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssertionsTestProject
{
    [TestFixture]
    public class UnitTestsUsingNUnit
    {
        [Test]
        public void IsStringContainsSubstring()
        {
            string stringValue = "programming language";
            string substring = "program";

            Assert.That(stringValue, Contains.Substring(substring).IgnoreCase);
        }

        [Test]
        public void IsValidEmail()
        {
            string email = "sasha@mail.ru";
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            StringAssert.IsMatch(emailPattern, email);
        }

        [Test]
        public void IsObjectsReferToSameObject()
        {
            object obj1 = new object();
            object obj2 = obj1;
            object obj3 = obj1;

            Assert.AreSame(obj2, obj3);
        }

        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(1, 0, 0)]
        [TestCase(-4, 6, -24)]
        [TestCase(-4, -6, 24)]
        public void IsConditionTrue(int value1, int value2, int result)
        {
            Assert.IsTrue(value1 * value2 == result);
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(1, 0, 1)]
        [TestCase(-4, 6, 24)]
        [TestCase(-4, -6, -24)]
        public void IsConditionFalse(int value1, int value2, int result)
        {
            Assert.IsFalse(value1 * value2 == result);
        }

        [Test]
        public void IsCollectionsEquals()
        {
            List<int> list1 = new List<int>() {1, 2, 3, 4};
            List<int> list2 = new List<int>() {1, 2, 3, 4};

            CollectionAssert.AreEqual(list1, list2);
        }

        [Test]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void IsCollectionContainsEl(int elem)
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4 };

            CollectionAssert.Contains(list1, elem);
        }

        [Test]
        public void IsMethodThrowsException()
        {
            Assert.Throws<InvalidCastException>(new TestDelegate(MethodThatThrowsException));
        }

        private void MethodThatThrowsException()
        {
            object obj = "some string";
            int num = (int) obj;
        }
    }
}