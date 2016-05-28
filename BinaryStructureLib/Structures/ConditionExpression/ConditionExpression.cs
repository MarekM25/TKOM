using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    public abstract class Expression
    {
        public abstract bool Evaluate();
        //private IInterpreterService interpreterService;

        //public Expression(IInterpreterService interpreterService)
        //{
        //    this.interpreterService = interpreterService;
        //}
    }
}
