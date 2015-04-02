using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Soltys.ChangeCase.Tests
{
    [TestFixture]
    public class CamelCaseTests
    {
        [Test]
        public void SingleWordTest()
        {
            TestCamelCase("test", "test");
            TestCamelCase("TEST", "test");
        }


        [Test]
        public void RegularSentenceCasedStringsTest()
        {
            TestCamelCase("test string", "testString");
            TestCamelCase("Test String", "testString");
        }

        [Test]
        public void NonAlphanumericSeparatorsTest()
        {
            TestCamelCase("dot.case", "dotCase");
            TestCamelCase("path/case", "pathCase");
        }

        [Test]
        public void UnderscorePeriodsInsideNumbersTest()
        {
            TestCamelCase("version 1.2.10","version1_2_10");
            TestCamelCase("version 1.21.0","version1_21_0");
        }

        [Test]
        public void PascalCasedStringTest()
        {
            TestCamelCase("TestString", "testString");
        }

        [Test]
        public void NonLatinStringsTest()
        {
            TestCamelCase("simple éxample", "simpleÉxample");
        }


        [Test]
        public void LocaleTest()
        {
            string actual = "A STRING".CamelCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("aStrıng", actual);
        }

        private void TestCamelCase(string input, string expected)
        {
            string actual = input.CamelCase();
            Assert.AreEqual(expected, actual);
        }
    }
}
