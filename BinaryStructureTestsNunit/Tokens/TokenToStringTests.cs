using BinaryStructureLib;
using BinaryStructureLib.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit
{
    [TestFixture]
    public class TokenToStringTests
    {
        [Test]
        public void ToStringTokenTests()
        {
            var token = new TokenKeyword(Keywords.BoolType);
            var actual = token.ToString();
            var expected = "TokenType: TokenKeyword, Value: BoolType";
            Assert.AreEqual(expected, actual);
        }
    }
}
