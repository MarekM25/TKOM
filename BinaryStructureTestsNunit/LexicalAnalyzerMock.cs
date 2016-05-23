using BinaryStructureLib;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit
{
    public class LexicalAnalyzerMock : ILexicalAnalyzer
    {
        private TokenBase[] tokens;
        private int currentIndex;

        public LexicalAnalyzerMock(TokenBase[] tokens)
        {
            this.tokens = tokens;
            this.currentIndex = 0;
        }

        public TokenBase CurrentToken
        {
            get
            {
                return tokens[currentIndex];
            }
        }

        public TokenBase GetNextToken()
        {
            ++currentIndex;
            var token = tokens[currentIndex];
            return token;
        }

        public bool HasTokens()
        {
            return currentIndex +1 < tokens.Count();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
