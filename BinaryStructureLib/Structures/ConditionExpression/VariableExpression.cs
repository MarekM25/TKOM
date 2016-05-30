using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class VariableExpression : Expression, IGenericValue<int>
    {
        public string Name { get; set; }


        public VariableExpression(string name)
        {
            this.Name = name;
        }

        public override bool Evaluate(IInterpreterService interpreterService)
        {
            throw new NotImplementedException();
        }

        public int Value(IInterpreterService interpreterService)
        {
            object o = interpreterService.GetValue(Name);
            return (int)o;
        }
    }
}
