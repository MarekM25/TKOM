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

        public Parser(ILexicalAnalyzer lexicalAnalyzer)
        {
            ParserService.Initialize(lexicalAnalyzer);
        }

        public BinaryStructure Parse()
        {
            while (ParserService.Accept(new TokenKeyword(Keywords.StructType)))
            {
                var structParser = new StructParser();
                binaryStructure.stuctDeclarations.Add(structParser.Parse());
            }
            binaryStructure.mainStructure = MainParser.Parse();
            return binaryStructure;
        }

        //private void ParameterLists()
        //{
        //    Expect(Operators.OpeningCircleBracket);
        //    do
        //    {
        //        Parameter();
        //    } while (Accept(Operators.Comma));
        //    Expect(Operators.ClosingCircleBracket);
        //}

        //private void Parameter()
        //{
            
        //}

        //private void StructDeclarations()
        //{
        //    if (Accept(Keywords.StructType)) 
        //    {
        //        ParameterLists();
                
                
        //       // Expect()
        //        if (Accept(Keywords.Begin))
        //        {

        //            //loop statements
        //            if (Accept(Keywords.End))
        //            {

        //            }
        //        }
        //    }
        //}

    }
}
