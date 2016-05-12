using BinaryStructureLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.LexicalAnalyzer
{
    public class LexicalAnalyzerMock : ILexicalAnalyzer
    {
        private Token[] tokens;
        private int nextIndex;

        public LexicalAnalyzerMock(Token[] tokens)
        {
            this.tokens = tokens;
            this.nextIndex = 0;
        }

        public Token CurrentToken
        {
            get
            {
                return tokens[nextIndex];
            }
        }

        public Token GetNextToken()
        {
            var token = tokens[nextIndex];
            ++nextIndex;
            return token;
        }

        public bool HasTokens()
        {
            throw new NotImplementedException();
        }
    }
}
