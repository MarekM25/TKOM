using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureTestsNunit.LexicalAnalyzer;
using BinaryStructureLib;
using BinaryStructureLib.Tokens;

namespace BinaryStructureTestsNunit.Parser
{
    [TestFixture]
    public class StructParserTests
    {
        private Token[] tokens = new Token[]
            {  new Token(TokenType.Keyword, Keywords.StructType) };
        [Test]
        public void Test()
        {
            var keyword = new TokenKeyword(Keywords.False);
            var oper = new TokenOperator(Operators.LogicAnd);
            keyword.Equals(oper);
            //ParserService.Initialize(new LexicalAnalyzerMock(tokens));
            //StructParser.Parse();
        } 
    }
}
