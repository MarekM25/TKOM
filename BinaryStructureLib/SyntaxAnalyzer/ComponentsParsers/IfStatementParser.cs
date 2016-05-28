using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class IfStatementParser
    {
        private BoolExpressionListsParser conditionParser;
        private BlockParser ifBlockParser;
        private BlockParser elseBlockParser;
        private ParserService parserService;

        public IfStatementParser(ParserService parserService)
        {
            this.parserService = parserService;
            this.conditionParser = new BoolExpressionListsParser(parserService);
            this.ifBlockParser = new BlockParser(parserService);
            this.elseBlockParser = new BlockParser(parserService);
    }

        public IfStatement Parse()
        {
            IfStatement ifStatement = new IfStatement();
            parserService.Expect(new TokenKeyword(Keywords.If));
            ifStatement.condition = conditionParser.Parse();
            ifStatement.statements = ifBlockParser.Parse();
            if (parserService.Accept(new TokenKeyword(Keywords.Else)))
            {
                ifStatement.hasAlternatives = true;
                var elseBlockParser = new BlockParser(parserService);
                ifStatement.alternativeStatements = elseBlockParser.Parse();
            }
            return ifStatement;
        }
    }
}
