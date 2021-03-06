﻿using System;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace AssertionsTestProject.UnitTests
{
    public class UnitTestsUsingXUnit
    {
        [Fact]
        public void IsStringContainsSubstring()
        {
            var stringValue = "programming language";
            var substring = "program";

            Assert.Contains(substring, stringValue);
        }

        [Fact]
        public void IsValidEmail()
        {
            var email = "sasha@mail.ru";
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            Assert.Matches(emailPattern, email);
        }

        [Fact]
        public void IsObjectsReferToSameObject()
        {
            var obj1 = new object();
            var obj2 = obj1;
            var obj3 = obj1;

            Assert.Same(obj2, obj3);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(1, 0, 0)]
        [InlineData(-4, 6, -24)]
        [InlineData(-4, -6, 24)]
        public void IsConditionTrue(int value1, int value2, int result)
        {
            Assert.True(value1 * value2 == result);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(1, 0, 1)]
        [InlineData(-4, 6, 24)]
        [InlineData(-4, -6, -24)]
        public void IsConditionFalse(int value1, int value2, int result)
        {
            Assert.False(value1 * value2 == result);
        }

        [Fact]
        public void IsCollectionsEqual()
        {
            var list1 = new List<int>() {1, 2, 3, 4};
            var list2 = new List<int>() {1, 2, 3, 4};

            Assert.Equal(list1, list2);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void IsCollectionContainsEl(int elem)
        {
            var list1 = new List<int>() {1, 2, 3, 4};

            Assert.Contains(elem, list1);
        }

        [Fact]
        public void IsMethodThrowsException()
        {
            Assert.Throws<InvalidCastException>(new Action(MethodThatThrowsException));
        }

        private void MethodThatThrowsException()
        {
            object obj = "some string";
            var num = (int) obj;
        }
    }
}