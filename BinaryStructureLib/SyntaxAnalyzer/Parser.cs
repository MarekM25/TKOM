using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Parser : IParser
    {
        private BinaryStructure binaryStructure = new BinaryStructure();
        private ParserService parserService = new ParserService();
        public Parser(ILexicalAnalyzer lexicalAnalyzer)
        {
            parserService.Initialize(lexicalAnalyzer);
        }

        public BinaryStructure Parse()
        {
            while (parserService.Accept(new TokenKeyword(Keywords.StructType)))
            {
                var structParser = new StructParser(parserService);
                binaryStructure.stuctDeclarations.Add(structParser.Parse());
            }
            var mainParser = new MainParser(parserService);
            binaryStructure.mainStructure = mainParser.Parse();
            return binaryStructure;
        }
    }
}
