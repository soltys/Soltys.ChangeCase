using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Soltys.ChangeCase.Tests
{
    [TestFixture]
    public class UpperCaseFirstTests
    {
        [Test]
        public void UpperCaseFirstTest()
        {
            string input = null;
            Assert.AreEqual("", input.UpperCaseFirst());
            Assert.AreEqual("", "".UpperCaseFirst());
            Assert.AreEqual(" ", " ".UpperCaseFirst());
            Assert.AreEqual("Test", "test".UpperCaseFirst());
            Assert.AreEqual("TEST", "TEST".UpperCaseFirst());
            Assert.AreEqual("T", "t".UpperCaseFirst());
        }
    }
}
