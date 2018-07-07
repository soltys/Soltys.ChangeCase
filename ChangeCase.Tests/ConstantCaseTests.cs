using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class ConstantCaseTests
    {
        [Fact]
        public void RegularSentenceCaseTest()
        {
            TestConstantCase("test string", "TEST_STRING");
            TestConstantCase("Test String", "TEST_STRING");
        }

        [Fact]
        public void NonAlphanumericSeparatorsTest()
        {
            TestConstantCase("dot.case", "DOT_CASE");
            TestConstantCase("path/case", "PATH_CASE");
        }

        [Fact]
        public void MixStringsTest()
        {
            TestConstantCase("TestString", "TEST_STRING");
            TestConstantCase("TestString1_2_3", "TEST_STRING_1_2_3");
        }

        [Fact]
        public void NonLatinCharactersTest()
        {
            TestConstantCase("'My Entrée", "MY_ENTRÉE");
        }

        [Fact]
        public void LocaleSupportTest()
        {
            string actual = "myString".ConstantCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("MY_STRİNG", actual);
        }

        private void TestConstantCase(string input, string expected)
        {
            var actual = input.ConstantCase();
            Assert.Equal(expected, actual);
        }
    }
}
