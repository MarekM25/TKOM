using BinaryStructureLib;
using BinaryStructureLib.Structures.ConditionExpression;
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
    public class IfStatementParserTests
    {
        private ParserService parserService = new ParserService();
        private StructureBase structBaseMock = new StructureBase();
        private TokenBase[] simpleIfStatement = new TokenBase[]
        {
            new TokenKeyword(Keywords.If),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenKeyword(Keywords.True),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End)
        };

        private TokenBase[] ifWithAlternatives = new TokenBase[]
        {
            new TokenKeyword(Keywords.If),
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenKeyword(Keywords.True),
            new TokenOperator(Operators.ClosingCircleBracket),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna1"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna2"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End),
            new TokenKeyword(Keywords.Else),
            new TokenKeyword(Keywords.Begin),
            new TokenKeyword(Keywords.IntType),
            new TokenId("zmienna3"),
            new TokenKeyword(Keywords.Size),
            new TokenValue(8),
            new TokenOperator(Operators.Semicolon),
            new TokenKeyword(Keywords.End)
        };

        public IfStatementParserTests()
        {
            parserService.currentStructure = structBaseMock;
        }

        [Test]
        public void SimpleIfCountStatement()
        {
            parserService.Initialize(new LexicalAnalyzerMock(simpleIfStatement));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(1, ifStatement.statements.Count());
        }

        [Test]
        public void SimpleIfInnerExpression()
        {
            parserService.Initialize(new LexicalAnalyzerMock(simpleIfStatement));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var expected = new Likeness<ConstantBool, ConstantBool>(new ConstantBool(true));
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(expected,ifStatement.condition);
        }

        [Test]
        public void SimpleIfHasAlternative()
        {
            parserService.Initialize(new LexicalAnalyzerMock(simpleIfStatement));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(false, ifStatement.hasAlternatives);
        }

        [Test]
        public void IfWitAlternativesHasAlternatives()
        {
            parserService.Initialize(new LexicalAnalyzerMock(ifWithAlternatives));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(true, ifStatement.hasAlternatives);
        }

        [Test]
        public void IfWitAlternativesStatementsCount()
        {
            parserService.Initialize(new LexicalAnalyzerMock(ifWithAlternatives));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(2, ifStatement.statements.Count());
        }

        [Test]
        public void IfWitAlternativesAlternativesCount()
        {
            parserService.Initialize(new LexicalAnalyzerMock(ifWithAlternatives));
            IfStatementParser statementParser = new IfStatementParser(parserService);
            var ifStatement = statementParser.Parse() as IfStatement;
            Assert.AreEqual(1, ifStatement.alternativeStatements.Count());
        }

    }
}
