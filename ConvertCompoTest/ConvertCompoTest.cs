using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertComponent;
using System;

namespace ConvertCompoTest
{
    [TestClass]
    public class ConvertCompoTest
    {
        ConvertCompo cc = new ConvertCompo();

        [TestMethod]
        public void GramToOuncesTest()
        {
            Assert.AreEqual(0.035273961, cc.GramToOunces(1), 0.0001);
        }

        [TestMethod]
        public void OuncesToGramTest()
        {
            Assert.AreEqual(28.3495231, cc.OuncesToGram(1));
        }
    }
}
