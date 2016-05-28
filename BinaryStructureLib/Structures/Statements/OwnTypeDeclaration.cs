using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Analyzer;

namespace BinaryStructureLib.Structures.Statements
{
    public class OwnTypeDeclaration : Statement
    {
        public string TypeName { get; set; }
        public List<object> Values = new List<object>();

        public override List<InterpreterResult> Interpret(IInterpreterService interpreterService)
        {
            interpreterService.InterpretStructure(this);
            throw new NotImplementedException();
        }
    }
}
