using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Tokens;
using System.IO;
using BinaryStructureLib.Extensions;

namespace BinaryStructureLib.LexicalAnalayzer
{
    public class Scanner : ILexicalAnalyzer
    {
        private INextTokenStringReader nextTokenStringReader;
        private TokenStringMapper tokenStringMapper;

        private StreamReader streamReader;
        private bool hasTokens;

        public Scanner(StreamReader streamReader)
        {
            this.streamReader = streamReader;
            this.hasTokens = true;
            nextTokenStringReader = new NextTokenStringReader(streamReader);
            tokenStringMapper = new TokenStringMapper(nextTokenStringReader);
        }


        public TokenBase CurrentToken { get; internal set; }

        public TokenBase GetNextToken()
        {        
            var token = tokenStringMapper.MapNextWord();
#if DEBUG 
            System.Diagnostics.Debug.WriteLine(token.ToString());
#endif
            hasTokens = !nextTokenStringReader.EndOfStream;
            CurrentToken = token;
            return token;
        }

        public bool HasTokens()
        {
            return hasTokens;
        }

        public void Init()
        {
            ((ILexicalAnalyzer)this).GetNextToken();
        }
    }
}
