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
        private Structure structure = new Structure();
        private ParameterListParser parameterListParser = new ParameterListParser();
        private BlockParser structBlockParser = new BlockParser();

        public Structure Parse()
        {
            ParserService.Expect(new TokenId());
            structure.Name = (string)ParserService.PreviousTokenValue();
            structure.parameters = parameterListParser.Parse();
            structure.statements = structBlockParser.Parse();
            return structure;
        }
    }
}
