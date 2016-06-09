using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Exceptions
{
    public class SyntaxAnalyzerException : CompilerException
    {

        public SyntaxAnalyzerException() : base() { }

        public SyntaxAnalyzerException(string v) : base(v) { }

        public SyntaxAnalyzerException(TokenBase currentToken, string message) : base(string.Format("Blad podczas parsowania. {0} W poblizu {1} w linii {2}", message, currentToken.ToString(),currentToken.LineNumber)) { }

        public SyntaxAnalyzerException(TokenBase expected, TokenBase actual)
            : base(string.Format("Blad podczas parsowania. Oczekiwano {0}, a otrzymano {1} w linii {2}", expected.ToString(), actual.ToString(),actual.LineNumber))
        { }

    }
}
