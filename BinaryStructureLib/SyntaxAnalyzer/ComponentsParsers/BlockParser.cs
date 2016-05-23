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
        public List<Statement> Parse()
        {
            List<Statement> statements = new List<Statement>();
            ParserService.Expect(new TokenKeyword(Keywords.Begin));
            while (!ParserService.EqualsCurrentToken(new TokenKeyword(Keywords.End)))
            {
                var statementParser = new StatementParser();
                statements.Add(statementParser.Parse());
            }
            ParserService.Expect(new TokenKeyword(Keywords.End));
            return statements;
        }
    }
}
