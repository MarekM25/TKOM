using BinaryStructureLib;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
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
    public class MainParserTests
    {
        private TokenBase[] mainWithOneIntStatement = new TokenBase[]
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
            new TokenKeyword(Keywords.End),
};


        private TokenBase[] mainWithOwnType = new TokenBase[]
{
            new TokenKeyword(Keywords.Main),
            new TokenKeyword(Keywords.StructType),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenId("ownType"),
            new TokenId("zmienna1"),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End),
};




        private ParserService InitParserService(TokenBase[] tokenBaseArray)
        {
            ParserService parserService = new ParserService();
            StructureBase structBaseMock = new StructureBase();
            parserService.currentStructure = structBaseMock;
            parserService.Initialize(new LexicalAnalyzerMock(tokenBaseArray));
            return parserService;
        }


        [Test]
        public void MainWithOneIntStatementTests()
        {
            var parserService = InitParserService(mainWithOneIntStatement);
            var parser = new MainParser(parserService);
            var mainStruct = parser.Parse();
            Assert.AreEqual(1,mainStruct.Statements.Count());
        }

    }
}
