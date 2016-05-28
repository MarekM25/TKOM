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
        private BoolExpressionListsParser conditionParser = new BoolExpressionListsParser();
        private BlockParser ifBlockParser = new BlockParser();
        private BlockParser elseBlockParser = new BlockParser();

        public IfStatement Parse()
        {
            IfStatement ifStatement = new IfStatement();
            ParserService.Expect(new TokenKeyword(Keywords.If));
            ifStatement.condition = conditionParser.Parse();
            ifStatement.statements = ifBlockParser.Parse();
            if (ParserService.Accept(new TokenKeyword(Keywords.Else)))
            {
                ifStatement.hasAlternatives = true;
                var elseBlockParser = new BlockParser();
                ifStatement.alternativeStatements = elseBlockParser.Parse();
            }
            return ifStatement;
        }
    }
}
