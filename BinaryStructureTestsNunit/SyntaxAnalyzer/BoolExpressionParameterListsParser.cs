using BinaryStructureLib;
using BinaryStructureLib.Structures.ConditionExpression;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.Tokens;
using BinaryStructureTestsNunit.LexicalAnalyzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.SemanticComparison.Fluent;
using Ploeh.SemanticComparison;

namespace BinaryStructureTestsNunit.SyntaxAnalyzer
{
    [TestFixture]
    public class BoolExpressionParameterListsParser
    {
        private TokenBase[] onlyOneBoolExpressionTokens = new TokenBase[]
        {
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenKeyword(Keywords.True),
            new TokenOperator(Operators.ClosingCircleBracket)
        };

        private TokenBase[] onlyOneBinaryOperatorTokens = new TokenBase[]
{
            new TokenOperator(Operators.OpeningCircleBracket),
            new TokenKeyword(Keywords.True),
            new TokenOperator(Operators.LogicAnd),
            new TokenKeyword(Keywords.True),
            new TokenOperator(Operators.ClosingCircleBracket)
};

        public object BoolExpressionListParser { get; private set; }

        [Test]
        public void BoolExpressionSimpleTest()
        {
            ParserService.Initialize(new LexicalAnalyzerMock(onlyOneBoolExpressionTokens));
            var expression = BoolExpressionListsParser.Parse();
            var actualExpression = new Likeness<ConstantBool, ConstantBool>(expression as ConstantBool);
            Assert.AreEqual(new ConstantBool(true), actualExpression);
        }

        [Test]
        public void OneBinaryOperatorSimpleTest()
        {
            ParserService.Initialize(new LexicalAnalyzerMock(onlyOneBinaryOperatorTokens));
            BinaryOperator binaryOperatorExpression = BoolExpressionListsParser.Parse() as BinaryOperator;
            var constantBool = new Likeness<ConstantBool, ConstantBool>(new ConstantBool(true));
            Assert.AreEqual(binaryOperatorExpression.Symbol,'&');
            Assert.AreEqual(binaryOperatorExpression.Left, constantBool);
            Assert.AreEqual(binaryOperatorExpression.Right, constantBool);
        }
    }
}
