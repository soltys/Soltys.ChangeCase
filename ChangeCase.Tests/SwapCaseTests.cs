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
    class SwapCaseTests
    {
        [Test]
        public void SwapCaseInStringsTest()
        {
            string input = null;
            Assert.AreEqual(input.SwapCase(),"");
            Assert.AreEqual("test".SwapCase(), "TEST");
            Assert.AreEqual("TEST".SwapCase(), "test");
            Assert.AreEqual("PascalCase".SwapCase(), "pASCALcASE");
            Assert.AreEqual("Iñtërnâtiônàlizætiøn".SwapCase(), "iÑTËRNÂTIÔNÀLIZÆTIØN");
        }

        [Test]
        public void LocaleSupportTest()
        {
            Assert.AreEqual("mY sTRİNG", "My String".SwapCase(CultureInfo.CreateSpecificCulture("tr")));
        }
    }
}
