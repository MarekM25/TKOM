using BinaryStructureLib;
using BinaryStructureLib.Structures.ConditionExpression;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.Interpreter
{
    [TestFixture]
    public class BoolExpressionInterpreterTests
    {
        [TestCase(Operators.LogicAnd,true,true,ExpectedResult = true)]
        [TestCase(Operators.LogicAnd, true, false, ExpectedResult = false)]
        [TestCase(Operators.LogicAnd, false, true, ExpectedResult = false)]
        [TestCase(Operators.LogicAnd, false, false, ExpectedResult = false)]
        [TestCase(Operators.LogicOr, true, true, ExpectedResult = true)]
        [TestCase(Operators.LogicOr, true, false, ExpectedResult = true)]
        [TestCase(Operators.LogicOr, false, true, ExpectedResult = true)]
        [TestCase(Operators.LogicOr, false, false, ExpectedResult = false)]
        public bool SimpleEvalute(Operators symbol, bool firstBool, bool secondBool)
        {
            Expression simpleExpression = new BinaryOperator(symbol, new ConstantBool(firstBool), new ConstantBool(secondBool));
            return simpleExpression.Evaluate(null);
        }

        [TestCase(Operators.LogicAnd,Operators.LogicAnd, true, true, true, ExpectedResult = true)]
        [TestCase(Operators.LogicAnd, Operators.LogicAnd, true, true, false, ExpectedResult = false)]
        [TestCase(Operators.LogicAnd, Operators.LogicAnd, false, true, true, ExpectedResult = false)]
        [TestCase(Operators.LogicOr, Operators.LogicOr, true, true, true, ExpectedResult = true)]
        [TestCase(Operators.LogicOr, Operators.LogicOr, true, false, false, ExpectedResult = true)]
        [TestCase(Operators.LogicAnd, Operators.LogicOr, true, true, false, ExpectedResult = false)]
        public bool TwoOperatorsExample(Operators firstSymbol,Operators secondSymbol, bool firstBool, bool secondBool, bool thirdBool)
        {
            Expression simpleExpression = new BinaryOperator(firstSymbol,
                        new BinaryOperator(secondSymbol,new ConstantBool(firstBool),new ConstantBool(secondBool)),
                        new ConstantBool(thirdBool));
            return simpleExpression.Evaluate(null);
        }
        
        [TestCase(Operators.LogicCompare,3,3,ExpectedResult = true)]
        [TestCase(Operators.Greater, 4, 3, ExpectedResult = true)]
        [TestCase(Operators.Smaller, 3, 4, ExpectedResult = true)]
        [TestCase(Operators.LogicCompare, 3, 1, ExpectedResult = false)]
        [TestCase(Operators.Smaller, 3, 1, ExpectedResult = false)]
        [TestCase(Operators.Greater, 1, 3, ExpectedResult = false)]
        public bool SimpleIntComparasion(Operators symbol, int firstValue,int secondValue)
        {
            Expression simpleExpression = new BinaryOperator(symbol,
                new ConstantInt(firstValue),
                new ConstantInt(secondValue));
            return simpleExpression.Evaluate(null);
        }

    }
}
