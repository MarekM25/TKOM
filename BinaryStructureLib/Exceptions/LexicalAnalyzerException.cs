using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class LexicalAnalyzerException : Exception
    {
        public LexicalAnalyzerException() : base() { }
        public LexicalAnalyzerException(string word) 
            : base(string.Format("Błąd podczas analizy leksykalnej podczas przetwarzania: {0}",
                word)) { }
    }
}
