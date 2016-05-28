using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.Statements
{
    public class ArrayVariableDeclaration : VariableDeclaration
    {
        public int Length { get; set; }
        public string LengthVariableName { get; set; }
        public bool HasLengthValue { get; set; }

        public override List<InterpreterResult> Interpret(InterpreterService interpreterService)
        {
            var results = new List<InterpreterResult>();
            for (int i = 0; i < Length; ++i)
            {
                var result = new InterpreterResult();
                result.Name = this.Name;
                result.Size = this.Size;
                result.Value = interpreterService.ReadValue(Size);
                results.Add(result);
            }
            return results;
        }
    }
}
