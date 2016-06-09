using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Extensions
{
    public static class StreamReaderExtensions
    {
        public static int SkipWhitespaceWithLineCount(this StreamReader streamReader)
        {
            int lineCounter = 0;
            char nextChar = (char)streamReader.Peek();
            while (Char.IsWhiteSpace(nextChar))
            {
                if (nextChar == 13)
                    ++lineCounter;
                streamReader.Read();
                nextChar = (char)streamReader.Peek();
            }
            return lineCounter;
        }
    }
}
