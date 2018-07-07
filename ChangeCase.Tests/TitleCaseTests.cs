using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class TitleCaseTests
    {
        

        [Fact]
        public void SingleWordTest()
        {
            TestTitleCase("test", "Test");
            TestTitleCase("TEST", "Test");
        }

        [Fact]
        public void RegularSentenceTest()
        {
            TestTitleCase("test string", "Test String");
            TestTitleCase("Test String", "Test String");
        }

        [Fact]
        public void NonAlphanumericSeparatorTest()
        {
            TestTitleCase("dot.case", "Dot Case");
            TestTitleCase("path/case", "Path Case");
        }

        [Fact]
        public void PascalCasedStringsTest()
        {
            TestTitleCase("TestString", "Test String");
            TestTitleCase("TestString1_2_3", "Test String 1 2 3");
        }


        [Fact]
        public void CamelCasedStringsTest()
        {
            TestTitleCase("testString", "Test String");
        }

        [Fact]
        public void NonAsciiSupportTest()
        {
            TestTitleCase("éxample", "Éxample");
        }

        private void TestTitleCase(string input, string expected)
        {
            var actual = input.TitleCase();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TurkishTest()
        {
            string actual = "STRING".TitleCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("Strıng", actual);
        }
    }
}
