using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class StringTokenMapper
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
            { "then", new TokenKeyword(Keywords.Then) },
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

        public static TokenBase MapStringToToken(string stringToMap)
        {
            if (tokensDict.ContainsKey(stringToMap))
                return tokensDict[stringToMap];
            if (System.Text.RegularExpressions.Regex.IsMatch(stringToMap, "^\\d+$"))
                return new TokenValue(Convert.ToInt32(stringToMap));
            if (System.Text.RegularExpressions.Regex.IsMatch(stringToMap, "^[a-zA-Z][a-zA-Z0-9]*$"))
                return new TokenId(stringToMap);
            throw new LexicalAnalyzerException(stringToMap);
        }
    }
}
