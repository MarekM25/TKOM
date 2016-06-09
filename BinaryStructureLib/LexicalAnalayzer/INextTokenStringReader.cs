using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.LexicalAnalayzer
{
    public interface INextTokenStringReader
    {
        bool IsCurrentDigitsOnly { get; }
        bool IsCurrentDigitsOrLettersOnly { get; }
        bool EndOfStream { get; }
        int LineCounter { get; }
        string ReadNextTokenStringWord();
    }
}
