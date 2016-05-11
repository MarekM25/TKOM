using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib;

namespace TestsBinaryStructure
{
    [TestClass]
    public class CharExtensionsTests
    {
        [TestMethod]
        public void CheckEndingWordChar()
        {
            Assert.AreEqual(true, ';'.IsTokenWordChar());
            Assert.AreEqual(false, 'd'.IsTokenWordChar());
            Assert.AreEqual(false, ' '.IsTokenWordChar());
            Assert.AreEqual(true, '('.IsTokenWordChar());
        }

    }
}
