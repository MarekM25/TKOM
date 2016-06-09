using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Exceptions
{
    public class LexicalAnalyzerException : CompilerException
    {
        public LexicalAnalyzerException() : base() { }
        public LexicalAnalyzerException(string word, int lineNumber) 
            : base(string.Format("Blad podczas analizy leksykalnej podczas przetwarzania: {0} w linii {1}",
                word,lineNumber)) { }
    }
}
