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
        [TestCase('&',true,true,ExpectedResult = true)]
        [TestCase('&', true, false, ExpectedResult = false)]
        [TestCase('&', false, true, ExpectedResult = false)]
        [TestCase('&', false, false, ExpectedResult = false)]
        [TestCase('|', true, true, ExpectedResult = true)]
        [TestCase('|', true, false, ExpectedResult = true)]
        [TestCase('|', false, true, ExpectedResult = true)]
        [TestCase('|', false, false, ExpectedResult = false)]
        public bool SimpleEvalute(char symbol, bool firstBool, bool secondBool)
        {
            Expression simpleExpression = new BinaryOperator(symbol, new ConstantBool(firstBool), new ConstantBool(secondBool));
            return simpleExpression.Evaluate();
        }

        [TestCase('&','&', true, true, true, ExpectedResult = true)]
        [TestCase('&', '&', true, true, false, ExpectedResult = false)]
        [TestCase('&', '&', false, true, true, ExpectedResult = false)]
        [TestCase('|', '|', true, true, true, ExpectedResult = true)]
        [TestCase('|', '|', true, false, false, ExpectedResult = true)]
        [TestCase('&', '|', true, true, false, ExpectedResult = false)]
        public bool TwoOperatorsExample(char firstSymbol,char secondSymbol, bool firstBool, bool secondBool, bool thirdBool)
        {
            Expression simpleExpression = new BinaryOperator(firstSymbol,
                        new BinaryOperator(secondSymbol,new ConstantBool(firstBool),new ConstantBool(secondBool)),
                        new ConstantBool(thirdBool));
            return simpleExpression.Evaluate();
        }
        
        [TestCase('=',3,3,ExpectedResult = true)]
        [TestCase('>', 4, 3, ExpectedResult = true)]
        [TestCase('<', 3, 4, ExpectedResult = true)]
        [TestCase('=', 3, 1, ExpectedResult = false)]
        [TestCase('<', 3, 1, ExpectedResult = false)]
        [TestCase('>', 1, 3, ExpectedResult = false)]
        public bool SimpleIntComparasion(char symbol, int firstValue,int secondValue)
        {
            Expression simpleExpression = new BinaryOperator(symbol,
                new ConstantInt(firstValue),
                new ConstantInt(secondValue));
            return simpleExpression.Evaluate();
        }

    }
}
