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
    public class ParamCaseTests
    {
        [Test]
        public void SingleWordTest()
        {
            TestParamCase("test","test");
            TestParamCase("TEST","test");
        }

        [Test]
        public void RegularSentenceTest()
        {
            TestParamCase("test string", "test-string");
            TestParamCase("Test String", "test-string");
        }

        [Test]
        public void NonAlphanumericSeparatorsTest()
        {
            TestParamCase("dot.case", "dot-case");
            TestParamCase("path/case", "path-case");
        }

        [Test]
        public void NumbersTest()
        {
            TestParamCase("testString1_2_3", "test-string-1-2-3");
        }

        [Test]
        public void NonLatinStrings()
        {
            TestParamCase("My Entrée", "my-entrée");
        }

        [Test]
        public void LocaleTest()
        {
            string actual = "A STRING".ParamCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.AreEqual("a-strıng", actual);
        }

        private void TestParamCase(string input, string expected)
        {
            string actual = input.ParamCase();
            Assert.AreEqual(expected, actual);
        }
    }
}
