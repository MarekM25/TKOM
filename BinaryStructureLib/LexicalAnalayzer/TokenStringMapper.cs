using BinaryStructureLib.Exceptions;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.LexicalAnalayzer
{
    public class TokenStringMapper
    {
        private static Dictionary<string, TokenBase> tokensDict = new Dictionary<string, TokenBase>()
        {
            { "begin", new TokenKeyword(Keywords.Begin) },
            { "end", new TokenKeyword(Keywords.End) },
            { "struct", new TokenKeyword(Keywords.StructType) },
            { "int", new TokenKeyword(Keywords.IntType) },
            { "bool", new TokenKeyword(Keywords.BoolType) },
            { "size", new TokenKeyword(Keywords.Size) },
            { "if", new TokenKeyword(Keywords.If) },
            { "else", new TokenKeyword(Keywords.Else) },
            { "main", new TokenKeyword(Keywords.Main) },
            { "true", new TokenKeyword(Keywords.True) },
            { "false", new TokenKeyword(Keywords.False) },
            { "(", new TokenOperator(Operators.OpeningCircleBracket ) },
            { ")", new TokenOperator(Operators.ClosingCircleBracket) },
            { "[", new TokenOperator(Operators.OpeningSquareBracket) },
            { "]", new TokenOperator(Operators.ClosingSquareBracket) },
            { ",", new TokenOperator(Operators.Comma) },
            { ";", new TokenOperator(Operators.Semicolon) },
            { "&", new TokenOperator(Operators.LogicAnd) },
            { "|", new TokenOperator(Operators.LogicOr) },
            { "!", new TokenOperator(Operators.LogicNegation) },
            { "=", new TokenOperator(Operators.LogicCompare) },
            { ">", new TokenOperator(Operators.Greater) },
            { "<", new TokenOperator(Operators.Smaller) }
        };

        private INextTokenStringReader nextTokenStringReader;

        public TokenStringMapper(INextTokenStringReader nextTokenStringReader)
        {
            this.nextTokenStringReader = nextTokenStringReader;
        }

        private TokenBase MapToNextToken()
        {
            string nextWord = nextTokenStringReader.ReadNextTokenStringWord();
            if (tokensDict.ContainsKey(nextWord))
            {
                return tokensDict[nextWord];
            }
            if (nextTokenStringReader.IsCurrentDigitsOnly)
                return new TokenValue(Convert.ToInt32(nextWord));
            if (nextTokenStringReader.IsCurrentDigitsOrLettersOnly)
                return new TokenId(nextWord);
            throw new LexicalAnalyzerException(nextWord,nextTokenStringReader.LineCounter);
        }

        public TokenBase MapNextWord()
        {
            var token = MapToNextToken();
            token.LineNumber = nextTokenStringReader.LineCounter;
            return token;
        }
    }
}
