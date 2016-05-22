using BinaryStructureLib.Structures.ConditionExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.Statements
{
    public class IfStatement : Statement
    {
        public Expression condition { get; set; }
        public List<Statement> statements;
        public bool hasAlternatives { get; set; }
        public List<Statement> alternativeStatements;
    }
}
