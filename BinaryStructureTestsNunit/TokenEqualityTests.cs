using System;
using NUnit.Framework;
using BinaryStructureLib;

namespace BinaryStructureTestsNunit
{
    [TestFixture]
    public class TokenEqualityTests
    {
        [TestCase(TokenType.Keyword, Keywords.Begin)]
        [TestCase(TokenType.Keyword, "fas")]
        [TestCase(TokenType.Operator, Operators.ClosingSquareBracket)]
        [TestCase(TokenType.Id,3)]
        [TestCase(TokenType.Value, "dsa")]
        [TestCase(TokenType.Keyword, Keywords.Else)]
        public void SimpleTokenEquialityTests(TokenType tokenType, object value)
        {
            var actual = new Token() { Type = tokenType, Value = value};
            var expected = new Token() { Type = tokenType, Value = value };
            Assert.AreEqual(true, actual.Equals(expected));
        }

        [TestCase(TokenType.Keyword,Keywords.If,TokenType.Keyword,Keywords.If, ExpectedResult=true)]
        [TestCase(TokenType.Keyword, Keywords.If, TokenType.Keyword, Keywords.Else, ExpectedResult = false)]
        [TestCase(TokenType.Operator, Operators.LogicAnd, TokenType.Operator, Operators.Comma, ExpectedResult = false)]
        [TestCase(TokenType.Operator, Operators.Semicolon, TokenType.Operator, Operators.Semicolon, ExpectedResult = true)]
        [TestCase(TokenType.Id, "fd", TokenType.Id, "fd", ExpectedResult = true)]
        [TestCase(TokenType.Value, "fd", TokenType.Value, "fd", ExpectedResult = true)]
        [TestCase(TokenType.Id, "fd", TokenType.Id, "fd2", ExpectedResult = true)]
        [TestCase(TokenType.Value, "fd", TokenType.Value, "fd2", ExpectedResult = true)]
        [TestCase(TokenType.Value, "fd", TokenType.Id, "fd2", ExpectedResult = false)]
        [TestCase(TokenType.Keyword, "fd", TokenType.Id, "fd2", ExpectedResult = false)]
        [TestCase(TokenType.Keyword, "fd", TokenType.Operator, "fd2", ExpectedResult = false)]
        public bool TokenEqualityTest(TokenType expectedTokenType, object expectedValue, TokenType actualTokenType, object actualValue)
        {
            var actual = new Token() { Type = actualTokenType, Value = actualValue };
            var expected = new Token() { Type = expectedTokenType, Value = expectedValue };
            return actual.Equals(expected);
        }
    }
}