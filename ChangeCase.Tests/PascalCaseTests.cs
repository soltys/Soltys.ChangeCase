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
    class PascalCaseTests
    {
        [Test]
        public void SingleWordTest()
        {
            TestPascalCase("test", "Test");
            TestPascalCase("TEST", "Test");
        }


        [Test]
        public void RegularSentenceCasedStringsTest()
        {
            TestPascalCase("test string", "TestString");
            TestPascalCase("Test String", "TestString");
        }

        [Test]
        public void NonAlphanumericSeparatorsTest()
        {
            TestPascalCase("dot.case", "DotCase");
            TestPascalCase("path/case", "PathCase");
        }

        [Test]
        public void UnderscorePeriodsInsideNumbersTest()
        {
            TestPascalCase("version 1.2.10", "Version1_2_10");
            TestPascalCase("version 1.21.0", "Version1_21_0");
        }

        [Test]
        public void PascalCasedStringTest()
        {
            TestPascalCase("TestString", "TestString");
        }

        [Test]
        public void NonLatinStringsTest()
        {
            TestPascalCase("simple éxample", "SimpleÉxample");
        }


        [Test]
        public void LocaleTest()
        {
            string actual = "my STRING".PascalCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("MyStrıng", actual);
        }

        private void TestPascalCase(string input, string expected)
        {
            string actual = input.PascalCase();
            Assert.AreEqual(expected, actual);
        }
    }
}
