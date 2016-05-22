using System;
using NUnit.Framework;
using BinaryStructureLib;
using BinaryStructureLib.Tokens;
using System.Collections.Generic;

namespace BinaryStructureTestsNunit
{
    [TestFixture]
    public class TokenEqualityTests
    {        
        [TestCase(Keywords.Begin,Keywords.BoolType,ExpectedResult = false)]
        [TestCase(Keywords.Begin, Keywords.Begin, ExpectedResult = true)]
        [TestCase(Keywords.BoolType, Keywords.BoolType, ExpectedResult = true)]
        [TestCase(Keywords.Begin, Keywords.False, ExpectedResult = false)]
        [TestCase(Keywords.Main, Keywords.True, ExpectedResult = false)]
        [TestCase(Keywords.BoolType, Keywords.Begin, ExpectedResult = false)]
        [TestCase(Keywords.Main, Keywords.Main, ExpectedResult = true)]
        public bool TokenKeywordEqualsTest(Keywords firstKeyword ,Keywords secondKeyword)
        {
            var firstToken = new TokenKeyword(firstKeyword);
            var secondToken = new TokenKeyword(secondKeyword);
            return firstToken.Equals(secondToken);
        }

        [TestCase(Operators.ClosingCircleBracket, Operators.Comma, ExpectedResult = false)]
        [TestCase(Operators.LogicAnd, Operators.LogicAnd, ExpectedResult = true)]
        [TestCase(Operators.LogicNegation, Operators.LogicNegation, ExpectedResult = true)]
        [TestCase(Operators.Semicolon, Operators.ClosingSquareBracket, ExpectedResult = false)]
        [TestCase(Operators.LogicOr, Operators.OpeningSquareBracket, ExpectedResult = false)]
        [TestCase(Operators.Comma, Operators.Semicolon, ExpectedResult = false)]
        [TestCase(Operators.Semicolon, Operators.Semicolon, ExpectedResult = true)]
        public bool TokenOperatorEqualsTest(Operators firstOperator, Operators secondOperator)
        {
            var firstToken = new TokenOperator(firstOperator);
            var secondToken = new TokenOperator(secondOperator);
            return firstToken.Equals(secondToken);
        }

        [TestCase(ExpectedResult = false)]
        public bool OperatorKeywordEqualTest()
        {
            var firstToken = new TokenOperator(Operators.LogicNegation);
            var secondToken = new TokenKeyword(Keywords.Then);
            return firstToken.Equals(secondToken);
        }

        [TestCase(ExpectedResult = false)]
        public bool OperatorIdEqualTest()
        {
            var firstToken = new TokenOperator(Operators.LogicNegation);
            var secondToken = new TokenId("dsa");
            return firstToken.Equals(secondToken);
        }

        [TestCase(ExpectedResult = false)]
        public bool ValueIdEqualTest()
        {
            var firstToken = new TokenValue(3);
            var secondToken = new TokenId("dsa");
            return firstToken.Equals(secondToken);
        }

        [TestCase(1,3,ExpectedResult = true)]
        [TestCase(3, 3, ExpectedResult = true)]
        [TestCase(123, 3, ExpectedResult = true)]
        public bool ValueValueEqualTest(int first, int second)
        {
            var firstToken = new TokenValue(first);
            var secondToken = new TokenValue(second);
            return firstToken.Equals(secondToken);
        }

        [TestCase("dsa", "dasas", ExpectedResult = true)]
        [TestCase("dsa", "dsa", ExpectedResult = true)]
        [TestCase("fsafa", "dfass", ExpectedResult = true)]
        public bool IdIdEqualTest(string first, string second)
        {
            var firstToken = new TokenId(first);
            var secondToken = new TokenId(second);
            return firstToken.Equals(secondToken);
        }

        [TestCase(Keywords.Begin, Keywords.Begin, ExpectedResult = true)]
        [TestCase(Keywords.Begin, Keywords.False, ExpectedResult = false)]
        public bool KeywordsEqualTests(Keywords first, Keywords second)
        {
            var firstToken = new TokenKeyword(first);
            return firstToken.Equals(second);
        }

        [TestCase(Operators.LogicCompare, Operators.LogicCompare, ExpectedResult = true)]
        [TestCase(Operators.OpeningCircleBracket, Operators.Semicolon, ExpectedResult = false)]
        public bool OperatorsEqualTests(Operators first, Operators second)
        {
            var firstToken = new TokenOperator(first);
            return firstToken.Equals(second);
        }

        [TestCase(Keywords.Begin, ExpectedResult = false)]
        [TestCase(Keywords.IntType, ExpectedResult = false)]
        public bool NotKeywordsEqualTests(Keywords keyword)
        {
            var firstToken = new TokenOperator(Operators.Semicolon);
            return firstToken.Equals(keyword);
        }

        [TestCase(Operators.OpeningCircleBracket, ExpectedResult = false)]
        [TestCase(Operators.ClosingSquareBracket, ExpectedResult = false)]
        public bool NotOperatorEqualTests(Operators first)
        {
            var firstToken = new TokenId("dsa");
            return firstToken.Equals(first);
        }

        [TestCase(TokenType.Id, ExpectedResult = true)]
        [TestCase(TokenType.Operator, ExpectedResult = false)]
        public bool NotOperatorEqualTests(TokenType first)
        {
            var firstToken = new TokenId("dsa");
            return firstToken.Equals(first);
        }
    }
}