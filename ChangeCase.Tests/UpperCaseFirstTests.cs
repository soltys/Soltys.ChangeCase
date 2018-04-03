using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class UpperCaseFirstTests
    {
        [Fact]
        public void UpperCaseFirstTest()
        {
            string input = null;
            Assert.Equal("", input.UpperCaseFirst());
            Assert.Equal("", "".UpperCaseFirst());
            Assert.Equal(" ", " ".UpperCaseFirst());
            Assert.Equal("Test", "test".UpperCaseFirst());
            Assert.Equal("TEST", "TEST".UpperCaseFirst());
            Assert.Equal("T", "t".UpperCaseFirst());
        }
    }
}
