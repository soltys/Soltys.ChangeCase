using System.Globalization;
using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class SwapCaseTests
    {
        [Fact]
        public void SwapCaseInStringsTest()
        {
            string input = null;
            Assert.Equal("", input.SwapCase());
            Assert.Equal("TEST", "test".SwapCase());
            Assert.Equal("test", "TEST".SwapCase());
            Assert.Equal("pASCALcASE", "PascalCase".SwapCase());
            Assert.Equal("iÑTËRNÂTIÔNÀLIZÆTIØN", "Iñtërnâtiônàlizætiøn".SwapCase());
        }

        [Fact]
        public void LocaleSupportTest()
        {
            Assert.Equal("mY sTRİNG", "My String".SwapCase(CultureInfo.CreateSpecificCulture("tr")));
        }
    }
}
