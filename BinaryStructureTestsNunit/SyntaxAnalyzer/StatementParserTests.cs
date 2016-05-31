using BinaryStructureLib;
using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.Tokens;
using NUnit.Framework;
using Ploeh.SemanticComparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.SyntaxAnalyzer
{
    [TestFixture]
    public class StatementParserTests
    {
       // private ParserService parserService = new ParserService();
        //private StructureBase structBaseMock = new StructureBase();
        private TokenBase[] simpleVariableDeclarationTokens = new TokenBase[]
        {
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon)
        };

        private TokenBase[] simpleArrayVariableDeclarationTokens = new TokenBase[]
        {
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenOperator(Operators.OpeningSquareBracket),
            new TokenValue(4),
            new TokenOperator(Operators.ClosingSquareBracket),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon)
        };

        private TokenBase[] arrayVariableDeclarationWithLengthNameTokens = new TokenBase[]
        {
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenOperator(Operators.OpeningSquareBracket),
            new TokenId("zmienna2"),
            new TokenOperator(Operators.ClosingSquareBracket),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon)
        };

        private TokenBase[] ownTypeDeclarationTokens = new TokenBase[]
        {
            new TokenId("typStruktury"),
            new TokenId("zmienna1"),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenOperator(Operators.Semicolon)
        };

        public StatementParserTests()
        {
            //parserService.currentStructure = structBaseMock;
        }


        private ParserService InitParserService(TokenBase[] tokenBaseArray)
        {
            ParserService parserService = new ParserService();
            StructureBase structBaseMock = new StructureBase();
            parserService.currentStructure = structBaseMock;
            parserService.Initialize(new LexicalAnalyzerMock(tokenBaseArray));
            return parserService;
        }


        [Test]
        public void VariableDeclarationTests()
        {
            var parserService = InitParserService(simpleVariableDeclarationTokens);
            StatementParser statementParser = new StatementParser(parserService);
            var variableDeclaration = statementParser.Parse() as VariableDeclaration;
            var expected = new Likeness<VariableDeclaration, VariableDeclaration>(new VariableDeclaration() { Name = "zmienna1", Size = 8, Type = Keywords.IntType });
            Assert.AreEqual(expected, variableDeclaration);
        }

        [Test]
        public void ArrayVariableDeclarationTests()
        {
            var parserService = InitParserService(simpleArrayVariableDeclarationTokens);
            StatementParser statementParser = new StatementParser(parserService);
            var variableDeclaration = statementParser.Parse() as ArrayVariableDeclaration;
            var expected = new Likeness<ArrayVariableDeclaration, ArrayVariableDeclaration>(new ArrayVariableDeclaration()
            { Name = "zmienna1", Size = 8, Type = Keywords.IntType, Length = 4, HasLengthValue = true });
            Assert.AreEqual(expected, variableDeclaration);
        }

        [Test]
        public void ArrayVariableDeclarationWithLengthName()
        {
            var parserService = InitParserService(arrayVariableDeclarationWithLengthNameTokens);
            StatementParser statementParser = new StatementParser(parserService);
            var variableDeclaration = statementParser.Parse() as ArrayVariableDeclaration;
            var expected = new Likeness<ArrayVariableDeclaration, ArrayVariableDeclaration>(new ArrayVariableDeclaration()
            { Name = "zmienna1", Size = 8, Type = Keywords.IntType, LengthVariableName = "zmienna2", HasLengthValue = false });
            Assert.AreEqual(expected, variableDeclaration);
        }

        [Test]
        public void OwnTypeDeclarationsTokens()
        {
            var parserService = InitParserService(ownTypeDeclarationTokens);
            StatementParser statementParser = new StatementParser(parserService);
            var variableDeclaration = statementParser.Parse() as OwnTypeDeclaration;
            Assert.AreEqual("typStruktury", variableDeclaration.TypeName);
        }
    }
}
