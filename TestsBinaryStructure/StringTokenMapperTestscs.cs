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
    public class StringTokenMapperTestscs
    {
        [TestMethod]
        public void CorrectMapTests()
        {
            var actual = StringTokenMapper.MapStringToToken("begin");
            var expected = new Token() { Type = TokenType.Keyword, Value = (object)Keywords.Begin };

            Assert.AreEqual(expected, actual);

            actual = StringTokenMapper.MapStringToToken("(");
            expected = new Token() { Type = TokenType.Operator, Value = (object)Operators.OpeningSquareBracket };

            Assert.AreEqual(expected, actual);

            actual = StringTokenMapper.MapStringToToken(")");
            expected = new Token() { Type = TokenType.Operator, Value = (object)Operators.OpeningSquareBracket };

            Assert.AreNotEqual(expected, actual);

            actual = StringTokenMapper.MapStringToToken("tsafda");
            expected = new Token() { Type = TokenType.Id, Value = (object)"tsafda" };

            Assert.AreEqual(expected, actual);

            actual = StringTokenMapper.MapStringToToken("5321");
            expected = new Token() { Type = TokenType.Value, Value = (object)"5321" };

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(LexicalAnalyzerException),
    "Błąd podczas analizy leksykalnej podczas przetwarzania: 5321_")]
        public void WrongTokenTests()
        {
            StringTokenMapper.MapStringToToken("5321_");
        }

    }
}
