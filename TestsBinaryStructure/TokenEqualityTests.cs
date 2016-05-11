using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryStructureLib;

namespace TestsBinaryStructure
{
    [TestClass]
    public class TokenEqualityTests
    {
        [TestMethod]
        public void TokenEqualityTest(int d)
        {
            var actual = new Token(){Type = TokenType.Keyword,Value = (Keywords.Begin)};
            Assert.AreEqual(true, actual.Equals(new Token() { Type = TokenType.Keyword, Value = (Keywords.Begin) }));
        }
    }
}
