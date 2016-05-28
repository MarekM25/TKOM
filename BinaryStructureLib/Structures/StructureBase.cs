using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class StructureBase
    {
        public List<Statement> Statements;
        public Dictionary<string, object> Variables = new Dictionary<string, object>();
    }
}
