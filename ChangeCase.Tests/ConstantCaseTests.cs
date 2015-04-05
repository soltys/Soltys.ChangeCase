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
    class ConstantCaseTests
    {
        [Test]
        public void RegularSentenceCaseTest()
        {
            TestConstantCase("test string", "TEST_STRING");
            TestConstantCase("Test String", "TEST_STRING");
        }

        [Test]
        public void NonAlphanumericSeparatorsTest()
        {
            TestConstantCase("dot.case", "DOT_CASE");
            TestConstantCase("path/case", "PATH_CASE");
        }

        [Test]
        public void MixStringsTest()
        {
            TestConstantCase("TestString", "TEST_STRING");
            TestConstantCase("TestString1_2_3", "TEST_STRING_1_2_3");
        }

        [Test]
        public void NonLatinCharactersTest()
        {
            TestConstantCase("'My Entrée", "MY_ENTRÉE");
        }

        [Test]
        public void LocaleSupportTest()
        {
            string actual = "myString".ConstantCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("MY_STRİNG", actual);
        }

        private void TestConstantCase(string input, string expected)
        {
            var actual = input.ConstantCase();
            Assert.AreEqual(expected, actual);
        }
    }
}
