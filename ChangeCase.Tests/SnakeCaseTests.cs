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
    class SnakeCaseTests
    {
        [Test]
        public void RegularSentenceTest()
        {
            TestSnakeCase("test string", "test_string");
            TestSnakeCase("Test String", "test_string");
        }

        [Test]
        public void NonAlphanumericSeparatorsTest()
        {
            TestSnakeCase("dot.case", "dot_case");
            TestSnakeCase("path/case", "path_case");
        }

        [Test]
        public void MixStringsTest()
        {
            TestSnakeCase("TestString", "test_string");
            TestSnakeCase("TestString1_2_3", "test_string_1_2_3");
        }

        [Test]
        public void NonLatinCharactersTest()
        {
            TestSnakeCase("'My Entrée", "my_entrée");
        }

        [Test]
        public void LocaleSupportTest()
        {
            string actual = "MY STRING".SnakeCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("my_strıng", actual);
        }

        private void TestSnakeCase(string input, string expected)
        {
            var actual = input.SnakeCase();
            Assert.AreEqual(expected,actual);
        }
    }
}
