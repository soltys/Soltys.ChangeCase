using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class PascalCaseTests
    {
        [Fact]
        public void SingleWordTest()
        {
            TestPascalCase("test", "Test");
            TestPascalCase("TEST", "Test");
        }


        [Fact]
        public void RegularSentenceCasedStringsTest()
        {
            TestPascalCase("test string", "TestString");
            TestPascalCase("Test String", "TestString");
        }

        [Fact]
        public void NonAlphanumericSeparatorsTest()
        {
            TestPascalCase("dot.case", "DotCase");
            TestPascalCase("path/case", "PathCase");
        }

        [Fact]
        public void UnderscorePeriodsInsideNumbersTest()
        {
            TestPascalCase("version 1.2.10", "Version1_2_10");
            TestPascalCase("version 1.21.0", "Version1_21_0");
        }

        [Fact]
        public void PascalCasedStringTest()
        {
            TestPascalCase("TestString", "TestString");
        }

        [Fact]
        public void NonLatinStringsTest()
        {
            TestPascalCase("simple éxample", "SimpleÉxample");
        }


        [Fact]
        public void LocaleTest()
        {
            string actual = "my STRING".PascalCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("MyStrıng", actual);
        }

        private void TestPascalCase(string input, string expected)
        {
            string actual = input.PascalCase();
            Assert.Equal(expected, actual);
        }
    }
}
