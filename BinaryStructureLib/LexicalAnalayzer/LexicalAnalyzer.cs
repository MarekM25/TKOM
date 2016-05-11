using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class LexicalAnalyzer : ILexicalAnalyzer
    {
        private Stream stream;
        private bool hasTokens;

        public Token CurrentToken { get; internal set; }

        public LexicalAnalyzer(Stream stream)
        {
            this.stream = stream;
            this.hasTokens = true;
        }
        Token ILexicalAnalyzer.GetNextToken()
        {
            string nextWord = string.Empty;
            hasTokens = stream.NextWord(out nextWord);
            var token = StringTokenMapper.MapStringToToken(nextWord);
#if DEBUG 
            System.Diagnostics.Debug.WriteLine(token.ToString());
#endif
            CurrentToken = token;
            return token;
        }

        public bool HasTokens()
        {
            return hasTokens;
        }
    }
}
