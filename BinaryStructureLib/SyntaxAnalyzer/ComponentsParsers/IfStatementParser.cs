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
        private static IfStatement ifStatement;

        public static IfStatement Parse()
        {
            ifStatement.condition = BoolExpressionListsParser.Parse();
            ifStatement.statements = BlockParser.Parse();
            if (ParserService.Accept(new TokenKeyword(Keywords.Else)))
            {
                ifStatement.hasAlternatives = true;
                ifStatement.alternativeStatements = BlockParser.Parse();
            }
            return ifStatement;
        }
    }
}
