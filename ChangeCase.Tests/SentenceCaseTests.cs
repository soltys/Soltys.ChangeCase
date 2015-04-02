using System;
using System.Globalization;
using NUnit.Framework;

namespace Soltys.ChangeCase.Tests
{
    [TestFixture]
    public class SentenceCaseTests
    {
        [Test]
        public void NullInputTest()
        {
            TestSentenceCase(null, "");
        }

        [Test]
        public void NumberInputTest()
        {
            TestSentenceCase("10", "10");
        }

        [Test]
        public void SingleWordTest()
        {
            TestSentenceCase("test", "test");
            TestSentenceCase("TEST", "test");
        }

        [Test]
        public void CamelCaseTest()
        {
            TestSentenceCase("testString", "test string");
            TestSentenceCase("testString123", "test string 123");
        }

        [Test]
        public void NonAlphaNumericSeparatorsTest()
        {
            TestSentenceCase("dot.case", "dot case");
            TestSentenceCase("path/case", "path case");
            TestSentenceCase("snake_case", "snake case");
        }

        [Test]
        public void PunctuationTest()
        {
            TestSentenceCase("\"quotes\"", "quotes");
        }

        [Test]
        public void SpaceBetweenNumberPartsTest()
        {
            TestSentenceCase("version 0.45.0", "version 0 45 0");
            TestSentenceCase("version 0..78..9", "version 0 78 9");
            TestSentenceCase("version 4_99/4", "version 4 99 4");
        }


        [Test]
        public void WhitespaceTest()
        {
            TestSentenceCase("  test  ", "test");
        }

        [Test]
        public void NonAsciiChacterTest()
        {
            // Non-ascii characters.
            TestSentenceCase("español", "español");
            TestSentenceCase("Beyoncé Knowles", "beyoncé knowles");
            TestSentenceCase("Iñtërnâtiônàlizætiøn", "iñtërnâtiônàlizætiøn");
        }

        [Test]
        public void NumberStringInput()
        {
            // Number string input.
            TestSentenceCase("something2014other", "something 2014 other");
        }

        [Test]
        public void CustomReplacementTest()
        {
            // Custom replacement character
            TestSentenceCase("HELLO WORLD!", "hello_world", "_");
        }

        [Test]
        public void CustomLocaletest()
        {
            string actual = "A STRING".SentenceCase(" ", CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("a strıng", actual);
        }


        private static void TestSentenceCase(string input, string expected)
        {
            string actual = input.SentenceCase();
            Assert.AreEqual(expected, actual);
        }

        private static void TestSentenceCase(string input, string expected, string replacement)
        {
            string actual = input.SentenceCase(replacement);
            Assert.AreEqual(expected, actual);
        }
    }
}
