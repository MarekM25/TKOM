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
        public static void SkipWhitespace(this StreamReader streamReader)
        {
            char nextChar = (char)streamReader.Peek();
            while (Char.IsWhiteSpace(nextChar))
            {
                streamReader.Read();
                nextChar = (char)streamReader.Peek();
            }
        }
    }
}
