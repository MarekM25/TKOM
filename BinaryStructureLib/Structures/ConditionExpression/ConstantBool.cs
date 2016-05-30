using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class ConstantBool : Expression
    {
        public bool Value { get; set; }

        public ConstantBool(bool value)
        {
            this.Value = value;
        }

        public override bool Evaluate(IInterpreterService interpreterService)
        {
            return Value;
        }
    }
}
