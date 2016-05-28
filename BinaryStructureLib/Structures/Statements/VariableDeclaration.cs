using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.Statements
{
    public class VariableDeclaration :Statement
    {
        public Keywords Type { get; set; }

        public override List<InterpreterResult> Interpret(InterpreterService interpreterService)
        {
            //add local variable
            var result = new InterpreterResult();
            result.Name = this.Name;
            result.Size = this.Size;
            result.Value = interpreterService.ReadValue(Size);
            return new List<InterpreterResult>() { result };
        }
    }
}
