using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public interface ILexicalAnalyzer
    {
        Token GetNextToken();
        bool HasTokens();
        Token CurrentToken { get; }
    }
}
