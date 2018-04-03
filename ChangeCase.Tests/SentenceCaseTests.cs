using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class SentenceCaseTests
    {
        [Fact]
        public void NullInputTest()
        {
            TestSentenceCase(null, "");
        }

        [Fact]
        public void NumberInputTest()
        {
            TestSentenceCase("10", "10");
        }

        [Fact]
        public void SingleWordTest()
        {
            TestSentenceCase("test", "test");
            TestSentenceCase("TEST", "test");
        }

        [Fact]
        public void CamelCaseTest()
        {
            TestSentenceCase("testString", "test string");
            TestSentenceCase("testString123", "test string 123");
        }

        [Fact]
        public void NonAlphaNumericSeparatorsTest()
        {
            TestSentenceCase("dot.case", "dot case");
            TestSentenceCase("path/case", "path case");
            TestSentenceCase("snake_case", "snake case");
        }

        [Fact]
        public void PunctuationTest()
        {
            TestSentenceCase("\"quotes\"", "quotes");
        }

        [Fact]
        public void SpaceBetweenNumberPartsTest()
        {
            TestSentenceCase("version 1.2.10", "version 1 2 10");
            TestSentenceCase("version 0.45.0", "version 0 45 0");
            TestSentenceCase("version 0..78..9", "version 0 78 9");
            TestSentenceCase("version 4_99/4", "version 4 99 4");
        }


        [Fact]
        public void WhitespaceTest()
        {
            TestSentenceCase("  test  ", "test");
        }

        [Fact]
        public void NonAsciiChacterTest()
        {
            // Non-ascii characters.
            TestSentenceCase("español", "español");
            TestSentenceCase("Beyoncé Knowles", "beyoncé knowles");
            TestSentenceCase("Iñtërnâtiônàlizætiøn", "iñtërnâtiônàlizætiøn");
        }

        [Fact]
        public void NumberStringInput()
        {
            // Number string input.
            TestSentenceCase("something2014other", "something 2014 other");
        }

        [Fact]
        public void CustomReplacementTest()
        {
            // Custom replacement character
            TestSentenceCase("HELLO WORLD!", "hello_world", "_");
        }

        [Fact]
        public void CustomLocaletest()
        {
            string actual = "A STRING".SentenceCase(" ", CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("a strıng", actual);
        }


        private static void TestSentenceCase(string input, string expected)
        {
            string actual = input.SentenceCase();
            Assert.Equal(expected, actual);
        }

        private static void TestSentenceCase(string input, string expected, string replacement)
        {
            string actual = input.SentenceCase(replacement);
            Assert.Equal(expected, actual);
        }
    }
}
