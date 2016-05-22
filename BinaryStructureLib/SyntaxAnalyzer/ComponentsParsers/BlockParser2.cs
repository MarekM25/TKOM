using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class BlockParser2
    {
        public static List<Statement> Parse()
        {
            List<Statement> statements = new List<Statement>();
            ParserService.Expect(new TokenKeyword(Keywords.Begin));
            do
            {
                if (ParserService.Accept(new TokenKeyword(Keywords.If)))
                    IfStatementParser.Parse();
                else if (ParserService.Accept(new TokenKeyword(Keywords.BoolType))
                    || ParserService.Accept(new TokenKeyword(Keywords.BoolType)))
                    VariableDeclarationParser.Parse();
                else
                    OwnTypeDeclarationParser.Parse();
            } while (ParserService.Accept(new TokenKeyword(Keywords.End)));
            return statements;
        } 
    }
}
