using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.ConditionExpression
{
    interface IGenericValue<T>
    {
        T Value { get; set; }
    }
}
