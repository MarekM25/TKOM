using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class BlockParser
    {
        private static List<Statement> statements = new List<Statement>();

        public static List<Statement> Parse()
        {
            ParserService.Expect(new TokenKeyword(Keywords.Begin));
            while (!ParserService.EqualsCurrentToken(new TokenKeyword(Keywords.End)))
            {
                statements.Add(StatementParser.Parse());
            }
            ParserService.Expect(new TokenKeyword(Keywords.End));
            return statements;
        }
    }
}
