using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class ConstantInt : Expression, IGenericValue<int>
    {
        public int Value { get; set; }

        public ConstantInt(int value)
        {
            this.Value = value;
        }

        public override bool Evaluate(IInterpreterService interpreterService)
        {
            return Convert.ToBoolean(Value);
        }

        int IGenericValue<int>.Value(IInterpreterService interpreterService)
        {
            return Value;
        }
    }
}
