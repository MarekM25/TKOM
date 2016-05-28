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
    public class MainParser
    {
        private static MainStructure mainStructure = new MainStructure();
        private ParserService parserService;

        public MainParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public MainStructure Parse()
        {
            parserService.Expect(new TokenKeyword(Keywords.Main));
            parserService.Expect(new TokenKeyword(Keywords.StructType));
            parserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            var mainBlockParser = new BlockParser(parserService);
            mainStructure.Statements = mainBlockParser.Parse();
            return mainStructure;
        }
    }
}
