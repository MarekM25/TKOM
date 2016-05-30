using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Exceptions;
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

        private void AddStructure(Structure structure)
        {
            bool alreadyHasStructure = binaryStructure.stuctDeclarations.Any(x => x.Name == structure.Name);
            if (alreadyHasStructure)
                throw new SyntaxAnalyzerException(string.Format("Struktura o nazwie {0} już istnieje", structure.Name));
            binaryStructure.stuctDeclarations.Add(structure);
        }


        public BinaryStructure Parse()
        {
            while (parserService.Accept(new TokenKeyword(Keywords.StructType)))
            {
                var structParser = new StructParser(parserService);
                var structure = structParser.Parse();
                AddStructure(structure);
            }
            var mainParser = new MainParser(parserService);
            binaryStructure.mainStructure = mainParser.Parse();
            return binaryStructure;
        }
    }
}
