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

        private static Expression ParseBracket()
        {
            //token ++
            Expression expression = ParseExpression();
            ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return null;
        }

        private static Expression ParseConstantBool()
        {
            var expression = new ConstantBool(Convert.ToBoolean(ParserService.CurrentTokenValue()));
            ParserService.NextToken();
            return expression;
        }

        private static Expression ParseIntValue()
        {
            throw new NotImplementedException();
        }

        private static Expression ParseId()
        {
            throw new NotImplementedException();
        }


        private static Expression ParseTerm()
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

        private static Expression ParseExpression()
        {
            Expression expression = ParseTerm();      
            if (ParserService.Accept(new TokenOperator(Operators.LogicAnd))
                || ParserService.Accept(new TokenOperator(Operators.LogicCompare)) ||
                ParserService.Accept(new TokenOperator(Operators.LogicOr)) ||
                ParserService.Accept(new TokenOperator(Operators.Greater)) ||
                ParserService.Accept(new TokenOperator(Operators.Smaller)))
            {
                var binaryOperator = new BinaryOperator('&', expression, ParseTerm());
                return binaryOperator;
            }
            else
                return expression;
        }


        public static Expression Parse()
        {
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            Expression expression = ParseExpression();
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            return expression;
        }
    }
}
