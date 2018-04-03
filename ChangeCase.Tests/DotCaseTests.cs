using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class DotCaseTests
    {
        [Fact]
        public void NullInputTest()
        {
            TestDotCase(null, "");
        }

        [Fact]
        public void NumberInputTest()
        {
            TestDotCase("10", "10");
        }

        [Fact]
        public void SingleWordTest()
        {
            TestDotCase("test", "test");
            TestDotCase("TEST", "test");
        }

        [Fact]
        public void CamelCaseTest()
        {
            TestDotCase("testString", "test.string");
            TestDotCase("testString123", "test.string.123");
        }

        [Fact]
        public void NonAlphaNumericSeparatorsTest()
        {
            TestDotCase("dot.case", "dot.case");
            TestDotCase("path/case", "path.case");
            TestDotCase("snake_case", "snake.case");
        }

        [Fact]
        public void PunctuationTest()
        {
            TestDotCase("\"quotes\"", "quotes");
        }

        [Fact]
        public void SpaceBetweenNumberPartsTest()
        {
            TestDotCase("version 0.45.0", "version.0.45.0");
            TestDotCase("version 0..78..9", "version.0.78.9");
            TestDotCase("version 4_99/4", "version.4.99.4");
        }


        [Fact]
        public void WhitespaceTest()
        {
            TestDotCase("  test  ", "test");
        }

        [Fact]
        public void NonAsciiChacterTest()
        {
            // Non-ascii characters.
            TestDotCase("español", "español");
            TestDotCase("Beyoncé Knowles", "beyoncé.knowles");
            TestDotCase("Iñtërnâtiônàlizætiøn", "iñtërnâtiônàlizætiøn");
        }

        [Fact]
        public void NumberStringInput()
        {
            // Number string input.
            TestDotCase("something2014other", "something.2014.other");
        }



       

        [Fact]
        public void CustomLocaletest()
        {
            string actual = "A STRING".DotCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("a.strıng", actual);
        }


        private void TestDotCase(string input, string expected )
        {
            string actual = input.DotCase();
            Assert.Equal(expected, actual);
        }
     
    }
}
