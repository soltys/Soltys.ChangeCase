using Xunit;

namespace Soltys.ChangeCase.Tests
{
    public class LowerCaseFirstTests
    {
        [Fact]
        public void LowerCaseTest()
        {
            string input = null;
            Assert.Equal("", input.LowerCaseFirst());
            Assert.Equal("", "".LowerCaseFirst());
            Assert.Equal(" ", " ".LowerCaseFirst());
            Assert.Equal("test", "test".LowerCaseFirst());
            Assert.Equal("tEST", "TEST".LowerCaseFirst());
            Assert.Equal("t", "T".LowerCaseFirst());
        }
    }
}
