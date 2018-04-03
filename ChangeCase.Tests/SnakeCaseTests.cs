using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class SnakeCaseTests
    {
        [Fact]
        public void RegularSentenceTest()
        {
            TestSnakeCase("test string", "test_string");
            TestSnakeCase("Test String", "test_string");
        }

        [Fact]
        public void NonAlphanumericSeparatorsTest()
        {
            TestSnakeCase("dot.case", "dot_case");
            TestSnakeCase("path/case", "path_case");
        }

        [Fact]
        public void MixStringsTest()
        {
            TestSnakeCase("TestString", "test_string");
            TestSnakeCase("TestString1_2_3", "test_string_1_2_3");
        }

        [Fact]
        public void NonLatinCharactersTest()
        {
            TestSnakeCase("'My Entrée", "my_entrée");
        }

        [Fact]
        public void LocaleSupportTest()
        {
            string actual = "MY STRING".SnakeCase(CultureInfo.CreateSpecificCulture("tr"));
            Assert.Equal("my_strıng", actual);
        }

        private void TestSnakeCase(string input, string expected)
        {
            var actual = input.SnakeCase();
            Assert.Equal(expected,actual);
        }
    }
}
