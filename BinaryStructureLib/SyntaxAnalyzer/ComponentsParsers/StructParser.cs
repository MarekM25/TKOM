using BinaryStructureLib.Analyzer;
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
        private ParameterListParser parameterListParser;
        private BlockParser structBlockParser;
        private ParserService parserService;

        public StructParser(ParserService parserService)
        {
            this.parserService = parserService;
            this. parameterListParser = new ParameterListParser(parserService);
            this.structBlockParser = new BlockParser(parserService);
        }

        public Structure Parse()
        {
            parserService.currentStructure = structure;
            parserService.Expect(new TokenId());
            structure.Name = (string)parserService.PreviousTokenValue();
            structure.Parameters = parameterListParser.Parse();
            structure.Statements = structBlockParser.Parse();
            return structure;
        }
    }
}
