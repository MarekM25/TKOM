using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures
{
    public class Structure : StructureBase
    {
        public List<Parameter> Parameters = new List<Parameter>();
        

        public List<InterpreterResult> Interpret(IInterpreterService interpreterService)
        {
            List<InterpreterResult> results = new List<InterpreterResult>();
            foreach (var statement in this.Statements)
            {
                var statementInterpretResult = statement.Interpret(interpreterService);
                if (statementInterpretResult != null)
                    results.AddRange(statementInterpretResult);
            }
            return results;
        }
    }
}
