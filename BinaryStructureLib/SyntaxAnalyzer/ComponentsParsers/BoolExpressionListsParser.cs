using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures;
using BinaryStructureLib.Structures.ConditionExpression;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class BoolExpressionListsParser
    {
        private Expression ParseBracket()
        {
            //token ++
            Expression expression = ParseExpression();
            ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return null;
        }

        private Expression ParseConstantBool()
        {
            Keywords boolKeyword = (Keywords) ParserService.CurrentTokenValue();
            bool value = false;
            if (boolKeyword == Keywords.True)
                value = true;
            var expression = new ConstantBool(value);
            ParserService.NextToken();
            return expression;
        }

        private Expression ParseIntValue()
        {
            ParserService.Expect(new TokenValue());
            return new ConstantInt((int)ParserService.PreviousTokenValue());
        }

        private Expression ParseId()
        {
            ParserService.Expect(new TokenId());
            return new VariableExpression((string)ParserService.PreviousTokenValue()); 
        }


        private Expression ParseTerm()
        {
            if (ParserService.EqualsCurrentToken(new TokenOperator(Operators.OpeningCircleBracket)))
                return ParseBracket();
            if (ParserService.EqualsCurrentToken(new TokenKeyword(Keywords.True))
                || ParserService.EqualsCurrentToken(new TokenKeyword(Keywords.False)))
                return ParseConstantBool();
            if (ParserService.EqualsCurrentToken(new TokenValue()))
                return ParseIntValue();
            if (ParserService.EqualsCurrentToken(new TokenId()))
                return ParseId();
            return null;
        }


        private Expression ParseBinaryExpression(Expression leftExpression)
        {
            Operators symbol = (Operators)ParserService.PreviousTokenValue();
            var binaryOperator = new BinaryOperator(symbol, leftExpression, ParseTerm());
            return binaryOperator;
        }

        private Expression ParseExpression()
        {
            Expression expression = ParseTerm();      
            if (ParserService.Accept(new TokenOperator(Operators.LogicAnd)) || 
                ParserService.Accept(new TokenOperator(Operators.LogicCompare)) ||
                ParserService.Accept(new TokenOperator(Operators.LogicOr)) ||
                ParserService.Accept(new TokenOperator(Operators.Greater)) ||
                ParserService.Accept(new TokenOperator(Operators.Smaller)))
            {
                return ParseBinaryExpression(expression);
            }
            else
                return expression;
        }


        public Expression Parse()
        {
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            Expression expression = ParseExpression();
            ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return expression;
        }
    }
}
