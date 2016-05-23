using BinaryStructureLib;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryStructureTestsNunit.SyntaxAnalyzer
{
    [TestFixture]
    public class BinaryStructureParserTests
    {
        private TokenBase[] binaryWithOneStructure = new TokenBase[]
{
            new TokenKeyword(Keywords.StructType),
            new TokenId("test"),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(7),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End),
            new TokenKeyword(Keywords.Main),
            new TokenKeyword(Keywords.StructType),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(7),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna2"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(13),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna3"),
            new TokenOperator(Operators.OpeningSquareBracket),
            new TokenValue(4),
            new TokenOperator(Operators.ClosingSquareBracket),
            new TokenKeyword(Keywords.Size),
            new TokenValue(13),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End),
};



        private TokenBase[] mainWithTwoIntStatements = new TokenBase[]
{
            new TokenKeyword(Keywords.Main),
            new TokenKeyword(Keywords.StructType),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(7),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna2"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(13),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna3"),
            new TokenOperator(Operators.OpeningSquareBracket),
            new TokenValue(4),
            new TokenOperator(Operators.ClosingSquareBracket),
            new TokenKeyword(Keywords.Size),
            new TokenValue(13),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End),
};

        [Test]
        public void BinaryStructureCompleteTests()
        {
            var lex = new LexicalAnalyzerMock(mainWithTwoIntStatements);
            ParserService.Initialize(lex);
            var parser = new BinaryStructureLib.Parser(lex);
            parser.Parse();
        }

        [Test]
        public void BinaryWithOneStructureTests()
        {
            var lex = new LexicalAnalyzerMock(binaryWithOneStructure);
            ParserService.Initialize(lex);
            var parser = new BinaryStructureLib.Parser(lex);
            parser.Parse();
        }
    }
}
