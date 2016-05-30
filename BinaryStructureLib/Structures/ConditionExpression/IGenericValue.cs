using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Analyzer;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    interface IGenericValue<T>
    { 
        T Value(IInterpreterService interpreterService);
    }
}
