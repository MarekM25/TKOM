using BinaryStructureLib.Exceptions;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnconstrainedMelody;

namespace BinaryStructureLib.SyntaxAnalyzer
{
    public class ParserService
    {
        private ILexicalAnalyzer lexicalAnalyzer;
        private TokenBase previousToken;

        public void Initialize(ILexicalAnalyzer lexicalAnalyzer)
        {
            this.lexicalAnalyzer = lexicalAnalyzer;
        }


        public bool Accept<T>(T token) where T : TokenBase
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


        public void Expect<T>(T token) where T : TokenBase
        {
            if (!Accept(token))
                throw new SyntaxAnalyzerException(token, lexicalAnalyzer.CurrentToken);
        }

        public bool EqualsCurrentToken<T>(T token) where T : TokenBase
        {
            return lexicalAnalyzer.CurrentToken.Equals(token);
        }

        public bool EqualsPreviousToken<T>(T token) where T : TokenBase
        {
            return previousToken.Equals(token);
        }

        public object PreviousTokenValue()
        {
            return previousToken.GetValue();
        }

        public object CurrentTokenValue()
        {
            return lexicalAnalyzer.CurrentToken.GetValue();
        }

        public TokenBase NextToken()
        {
            previousToken = lexicalAnalyzer.CurrentToken;
            return lexicalAnalyzer.GetNextToken();
        }

        public TokenBase CurrentToken()
        {
            return lexicalAnalyzer.CurrentToken;
        }

    }
}
