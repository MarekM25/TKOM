using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnconstrainedMelody;

namespace BinaryStructureLib.SyntaxAnalyzer
{
    public static class ParserService
    {
        private static ILexicalAnalyzer lexicalAnalyzer;
        private static TokenBase previousToken;

        public static void Initialize(ILexicalAnalyzer lexicalAnalyzer)
        {
            ParserService.lexicalAnalyzer = lexicalAnalyzer;
        }

        //private static bool Accept(bool equalReturn)
        //{
        //    if (equalReturn)
        //    {
        //        previousToken = lexicalAnalyzer.CurrentToken;
        //        lexicalAnalyzer.GetNextToken();
        //        return true;
        //    }
        //    return false;
        //}


        //public static bool Accept(Keywords keyword)
        //{
        //    return Accept(lexicalAnalyzer.CurrentToken.Equals(keyword));
        //}

        //public static bool Accept(Operators oper)
        //{
        //    return Accept(lexicalAnalyzer.CurrentToken.Equals(oper));
        //}

        //public static bool Accept(TokenType type)
        //{
        //    return Accept(lexicalAnalyzer.CurrentToken.Equals(type));
        //}

        public static bool Accept<T>(T token) where T : TokenBase
        {
            if (lexicalAnalyzer.CurrentToken.Equals(token))
            {
                previousToken = lexicalAnalyzer.CurrentToken;
                if (lexicalAnalyzer.HasTokens())
                    lexicalAnalyzer.GetNextToken();
                return true;
            }
            return false;
        }

        //private static bool Expect(bool token)
        //{
        //    if (Accept(token))
        //        return true;
        //    //Parse exception//error("expect: unexpected symbol");
        //    return false;
        //}

        public static bool Expect<T>(T token) where T : TokenBase
        {
            if (Accept(token))
                return true;
            //Parse exception//error("expect: unexpected symbol");
            return false;
        }
        //public static bool Expect(Keywords keyword)
        //{
        //    return Accept(new TokenKeyword(keyword));
        //}

        //public static bool Expect(Operators oper)
        //{
        //    return Accept(new TokenOperator(oper));
        //}


        public static bool EqualsCurrentToken<T>(T token) where T : TokenBase
        {
            return lexicalAnalyzer.CurrentToken.Equals(token);
        }

        public static bool EqualsPreviousToken<T>(T token) where T : TokenBase
        {
            return previousToken.Equals(token);
        }

        public static object PreviousTokenValue()
        {
            return previousToken.GetValue();
        }

        public static object CurrentTokenValue()
        {
            return lexicalAnalyzer.CurrentToken.GetValue();
        }

        public static TokenBase NextToken()
        {
            previousToken = lexicalAnalyzer.CurrentToken;
            return lexicalAnalyzer.GetNextToken();
        }

        public static TokenBase CurrentToken()
        {
            return lexicalAnalyzer.CurrentToken;
        }

    }
}
