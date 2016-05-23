using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public class BinaryOperator : Expression
    {
        public Operators Symbol { get; set; }
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public BinaryOperator(Operators symbol, Expression left, Expression right)
        {
            this.Symbol = symbol;
            this.Left = left;
            this.Right = right;
        }


        public override bool Evaluate()
        {
            switch (Symbol)
            {
                case Operators.LogicAnd:
                        return Left.Evaluate() && Right.Evaluate();
                case Operators.LogicOr:
                    return Left.Evaluate() || Right.Evaluate();
                case Operators.Smaller:
                    return (Left as IGenericValue<int>).Value < (Right as IGenericValue<int>).Value;
                case Operators.Greater:
                    return (Left as IGenericValue<int>).Value > (Right as IGenericValue<int>).Value;
                default:
                    return (Left as IGenericValue<int>).Value == (Right as IGenericValue<int>).Value;
             }
        }
    }
}
