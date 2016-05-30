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

        public SyntaxAnalyzerException(TokenBase currentToken, string message) : base(string.Format("Błąd podczas parsowania. {0} W pobliżu {1}", message, currentToken.ToString())) { }

        public SyntaxAnalyzerException(TokenBase actual, TokenBase expected)
            : base(string.Format("Błąd podczas parsowania. Oczekiwano {0}, a otrzymano {1}", actual.ToString(), expected.ToString()))
        { }

    }
}
