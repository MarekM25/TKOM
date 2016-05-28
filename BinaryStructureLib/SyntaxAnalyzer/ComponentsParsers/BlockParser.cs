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
    public class BlockParser
    {
        private ParserService parserService;

        public BlockParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public List<Statement> Parse()
        {
            List<Statement> statements = new List<Statement>();
            parserService.Expect(new TokenKeyword(Keywords.Begin));
            while (!parserService.EqualsCurrentToken(new TokenKeyword(Keywords.End)))
            {
                var statementParser = new StatementParser(parserService);
                statements.Add(statementParser.Parse());
            }
            parserService.Expect(new TokenKeyword(Keywords.End));
            return statements;
        }
    }
}
