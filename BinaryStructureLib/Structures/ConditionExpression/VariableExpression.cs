using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class VariableExpression : Expression
    {
        public string Name { get; set; }

        public VariableExpression(string name)
        {
            this.Name = name;
        }

        public override bool Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
