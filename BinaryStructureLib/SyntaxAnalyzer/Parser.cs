using BinaryStructureLib.Structures;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Parser : IParser
    {

        public Parser(ILexicalAnalyzer lexicalAnalyzer)
        {
            ParserService.Initialize(lexicalAnalyzer);
        }

        public BinaryStructure Parse()
        {
            StructParser.Parse();
            return null;
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
