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
    public class DotCaseTests
    {
        [Test]
        public void NullInputTest()
        {
            TestDotCase(null, "");
        }

        [Test]
        public void NumberInputTest()
        {
            TestDotCase("10", "10");
        }

        [Test]
        public void SingleWordTest()
        {
            TestDotCase("test", "test");
            TestDotCase("TEST", "test");
        }

        [Test]
        public void CamelCaseTest()
        {
            TestDotCase("testString", "test.string");
            TestDotCase("testString123", "test.string.123");
        }

        [Test]
        public void NonAlphaNumericSeparatorsTest()
        {
            TestDotCase("dot.case", "dot.case");
            TestDotCase("path/case", "path.case");
            TestDotCase("snake_case", "snake.case");
        }

        [Test]
        public void PunctuationTest()
        {
            TestDotCase("\"quotes\"", "quotes");
        }

        [Test]
        public void SpaceBetweenNumberPartsTest()
        {
            TestDotCase("version 0.45.0", "version.0.45.0");
            TestDotCase("version 0..78..9", "version.0.78.9");
            TestDotCase("version 4_99/4", "version.4.99.4");
        }


        [Test]
        public void WhitespaceTest()
        {
            TestDotCase("  test  ", "test");
        }

        [Test]
        public void NonAsciiChacterTest()
        {
            // Non-ascii characters.
            TestDotCase("español", "español");
            TestDotCase("Beyoncé Knowles", "beyoncé.knowles");
            TestDotCase("Iñtërnâtiônàlizætiøn", "iñtërnâtiônàlizætiøn");
        }

        [Test]
        public void NumberStringInput()
        {
            // Number string input.
            TestDotCase("something2014other", "something.2014.other");
        }



       

        [Test]
        public void CustomLocaletest()
        {
            string actual = "A STRING".DotCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("a.strıng", actual);
        }


        private void TestDotCase(string input, string expected )
        {
            string actual = input.DotCase();
            Assert.AreEqual(expected, actual);
        }
     
    }
}
