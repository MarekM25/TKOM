using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Analyzer
{
    public struct InterpreterResult
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }
        public string StructureName { get; set; }
    }
}
