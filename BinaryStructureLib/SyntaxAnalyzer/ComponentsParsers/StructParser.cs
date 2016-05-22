using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class StructParser
    {
        private static Structure structure = new Structure();

        public static Structure Parse()
        {
            ParserService.Expect(new TokenId());
            structure.Name = (string)ParserService.PreviousTokenValue();
            structure.parameters = ParameterListParser.Parse();
            structure.statements = BlockParser.Parse();
            return structure;
        }
    }
}
