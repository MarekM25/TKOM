using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public interface ILexicalAnalyzer
    {
        TokenBase GetNextToken();
        bool HasTokens();
        TokenBase CurrentToken { get; }
        void Init();
    }
}
