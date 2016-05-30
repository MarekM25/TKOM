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
        private ParserService parserService;

        public BoolExpressionListsParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        private Expression ParseBracket()
        {
            parserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            Expression expression = ParseExpression();
            parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return expression;
        }

        private Expression ParseConstantBool()
        {
            Keywords boolKeyword = (Keywords) parserService.CurrentTokenValue();
            bool value = false;
            if (boolKeyword == Keywords.True)
                value = true;
            var expression = new ConstantBool(value);
            parserService.NextToken();
            return expression;
        }

        private Expression ParseIntValue()
        {
            parserService.Expect(new TokenValue());
            return new ConstantInt((int)parserService.PreviousTokenValue());
        }

        private Expression ParseId()
        {
            parserService.Expect(new TokenId());
            return new VariableExpression((string)parserService.PreviousTokenValue()); 
        }


        private Expression ParseTerm()
        {
            if (parserService.EqualsCurrentToken(new TokenOperator(Operators.OpeningCircleBracket)))
                return ParseBracket();
            if (parserService.EqualsCurrentToken(new TokenKeyword(Keywords.True))
                || parserService.EqualsCurrentToken(new TokenKeyword(Keywords.False)))
                return ParseConstantBool();
            if (parserService.EqualsCurrentToken(new TokenValue()))
                return ParseIntValue();
             return ParseId();
        }


        private Expression ParseBinaryExpression(Expression leftExpression)
        {
            Operators symbol = (Operators)parserService.PreviousTokenValue();
            var binaryOperator = new BinaryOperator(symbol, leftExpression, ParseTerm());
            return binaryOperator;
        }

        private Expression ParseExpression()
        {
            Expression expression = ParseTerm();      
            if (parserService.Accept(new TokenOperator(Operators.LogicAnd)) || 
                parserService.Accept(new TokenOperator(Operators.LogicCompare)) ||
                parserService.Accept(new TokenOperator(Operators.LogicOr)) ||
                parserService.Accept(new TokenOperator(Operators.Greater)) ||
                parserService.Accept(new TokenOperator(Operators.Smaller)))
            {
                return ParseBinaryExpression(expression);
            }
            else
                return expression;
        }


        public Expression Parse()
        {
            parserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            Expression expression = ParseExpression();
            parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return expression;
        }
    }
}
