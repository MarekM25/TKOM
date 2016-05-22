using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class VariableDeclarationParser
    {
        public static VariableDeclaration Parse()
        {
            ParserService.Expect(new TokenId());
            //parameter.Name = (string)ParserService.PreviousTokenValue();
            if (ParserService.Accept(new TokenOperator(Operators.OpeningSquareBracket)))
            {

            }
            ParserService.Expect(new TokenKeyword(Keywords.Size));
            ParserService.Expect(new TokenValue());
            //get size
            return null;
        }
    }
}
