using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class ParamCaseTests
    {
        [Fact]
        public void SingleWordTest()
        {
            TestParamCase("test","test");
            TestParamCase("TEST","test");
        }

        [Fact]
        public void RegularSentenceTest()
        {
            TestParamCase("test string", "test-string");
            TestParamCase("Test String", "test-string");
        }

        [Fact]
        public void NonAlphanumericSeparatorsTest()
        {
            TestParamCase("dot.case", "dot-case");
            TestParamCase("path/case", "path-case");
        }

        [Fact]
        public void NumbersTest()
        {
            TestParamCase("testString1_2_3", "test-string-1-2-3");
        }

        [Fact]
        public void NonLatinStrings()
        {
            TestParamCase("My Entrée", "my-entrée");
        }

        [Fact]
        public void LocaleTest()
        {
            string actual = "A STRING".ParamCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("a-strıng", actual);
        }

        private void TestParamCase(string input, string expected)
        {
            string actual = input.ParamCase();
            Assert.Equal(expected, actual);
        }
    }
}
