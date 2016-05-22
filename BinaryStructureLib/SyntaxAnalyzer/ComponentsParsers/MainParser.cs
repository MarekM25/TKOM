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

        public static MainStructure Parse()
        {
            ParserService.Expect(new TokenKeyword(Keywords.Main));
            ParserService.Expect(new TokenKeyword(Keywords.StructType));
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            mainStructure.statements = BlockParser.Parse();
            return mainStructure;
        }
    }
}
