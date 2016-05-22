using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class Negation : Expression
    {
        public Expression Right { get; set; }

        public Negation(Expression right)
        {
            this.Right = right;
        }

        public override bool Evaluate()
        {
            return !(Right.Evaluate());
        }
    }
}
