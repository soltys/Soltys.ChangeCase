using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Soltys.ChangeCase.Tests
{
    [TestFixture]
    class LowerCaseFirstTests
    {
        [Test]
        public void LowerCaseTest()
        {
            string input = null;
            Assert.AreEqual("", input.LowerCaseFirst());
            Assert.AreEqual("", "".LowerCaseFirst());
            Assert.AreEqual(" ", " ".LowerCaseFirst());
            Assert.AreEqual("test", "test".LowerCaseFirst());
            Assert.AreEqual("tEST", "TEST".LowerCaseFirst());
            Assert.AreEqual("t", "T".LowerCaseFirst());
        }
    }
}
