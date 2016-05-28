using BinaryStructureLib.Structures.ConditionExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Analyzer;

namespace BinaryStructureLib.Structures.Statements
{
    public class IfStatement : Statement
    {
        public Expression condition { get; set; }
        public List<Statement> statements;
        public bool hasAlternatives { get; set; }
        public List<Statement> alternativeStatements;

        public override List<InterpreterResult> Interpret(InterpreterService interpreterService)
        {
            throw new NotImplementedException();
        }
    }
}
