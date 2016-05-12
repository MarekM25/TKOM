using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class StructParser
    {
        public static void Parse()
        {
            if (ParserService.Accept(Keywords.StructType))
            {
            }
        }
    }
}
