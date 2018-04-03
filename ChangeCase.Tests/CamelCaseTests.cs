using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class CamelCaseTests
    {
        [Fact]
        public void SingleWordTest()
        {
            TestCamelCase("test", "test");
            TestCamelCase("TEST", "test");
        }


        [Fact]
        public void RegularSentenceCasedStringsTest()
        {
            TestCamelCase("test string", "testString");
            TestCamelCase("Test String", "testString");
        }

        [Fact]
        public void NonAlphanumericSeparatorsTest()
        {
            TestCamelCase("dot.case", "dotCase");
            TestCamelCase("path/case", "pathCase");
        }

        [Fact]
        public void UnderscorePeriodsInsideNumbersTest()
        {
            TestCamelCase("version 1.2.10","version1_2_10");
            TestCamelCase("version 1.21.0","version1_21_0");
        }

        [Fact]
        public void PascalCasedStringTest()
        {
            TestCamelCase("TestString", "testString");
        }

        [Fact]
        public void NonLatinStringsTest()
        {
            TestCamelCase("simple éxample", "simpleÉxample");
        }


        [Fact]
        public void LocaleTest()
        {
            string actual = "A STRING".CamelCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("aStrıng", actual);
        }

        private void TestCamelCase(string input, string expected)
        {
            string actual = input.CamelCase();
            Assert.Equal(expected, actual);
        }
    }
}
