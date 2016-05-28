using BinaryStructureLib.Structures.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures
{
    public class Structure : StructureBase
    {
        public List<Parameter> Parameters;
        public string Name { get; set; }
    }
}
