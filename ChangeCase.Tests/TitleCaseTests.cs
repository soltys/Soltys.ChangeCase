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
    class TitleCaseTests
    {
        

        [Test]
        public void SingleWordTest()
        {
            TestTitleCase("test", "Test");
            TestTitleCase("TEST", "Test");
        }

        [Test]
        public void RegularSentenceTest()
        {
            TestTitleCase("test string", "Test String");
            TestTitleCase("Test String", "Test String");
        }

        [Test]
        public void NonAlphanumericSeparatorTest()
        {
            TestTitleCase("dot.case", "Dot Case");
            TestTitleCase("path/case", "Path Case");
        }

        [Test]
        public void PascalCasedStringsTest()
        {
            TestTitleCase("TestString", "Test String");
            TestTitleCase("TestString1_2_3", "Test String 1 2 3");
        }


        [Test]
        public void CamelCasedStringsTest()
        {
            TestTitleCase("testString", "Test String");
        }

        [Test]
        public void NonAsciiSupportTest()
        {
            TestTitleCase("éxample", "Éxample");
        }

        private void TestTitleCase(string input, string expected)
        {
            var actual = input.TitleCase();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TurkishTest()
        {
            string actual = "STRING".TitleCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("Strıng", actual);
        }
    }
}
