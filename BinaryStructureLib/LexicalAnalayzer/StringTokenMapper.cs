using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class StringTokenMapper
    {
        private static Dictionary<string, Token> tokensDict = new Dictionary<string, Token>()
        {
            { "begin", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.Begin} },
            { "end", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.End} },
            { "struct", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.StructType} },
            { "int", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.IntType} },
            { "bool", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.BoolType} },
            { "size", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.Size} },
            { "if", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.If} },
            { "then", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.Then} },
            { "else", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.Else} },
            { "main", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.Main} },
            { "true", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.True} },
            { "false", new Token() { Type = TokenType.Keyword, Value = (object) Keywords.False} },
            { "(", new Token() { Type = TokenType.Operator, Value = (object) Operators.OpeningCircleBracket } },
            { ")", new Token() { Type = TokenType.Operator, Value = (object) Operators.ClosingCircleBracket} },
            { "[", new Token() { Type = TokenType.Operator, Value = (object) Operators.OpeningSquareBracket} },
            { "]", new Token() { Type = TokenType.Operator, Value = (object) Operators.ClosingSquareBracket} },
            { ",", new Token() { Type = TokenType.Operator, Value = (object) Operators.Comma} },
            { ";", new Token() { Type = TokenType.Operator, Value = (object) Operators.Semicolon} },
            { "&", new Token() { Type = TokenType.Operator, Value = (object) Operators.LogicAnd} },
            { "|", new Token() { Type = TokenType.Operator, Value = (object) Operators.LogicOr} },
            { "!", new Token() { Type = TokenType.Operator, Value = (object) Operators.LogicNegation} },
            { "=", new Token() { Type = TokenType.Operator, Value = (object) Operators.LogicCompare} }
        };

        public static Token MapStringToToken(string stringToMap)
        {
            if (tokensDict.ContainsKey(stringToMap))
                return tokensDict[stringToMap];
            if (System.Text.RegularExpressions.Regex.IsMatch(stringToMap, "^\\d+$"))
                return new Token() { Type = TokenType.Value, Value = (object)stringToMap };
            if (System.Text.RegularExpressions.Regex.IsMatch(stringToMap, "^[a-zA-Z][a-zA-Z0-9]*$"))
                return new Token() { Type = TokenType.Id, Value = (object)stringToMap };
            throw new LexicalAnalyzerException(stringToMap);
        }
    }
}
