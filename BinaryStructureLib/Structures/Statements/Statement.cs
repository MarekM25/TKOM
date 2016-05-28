using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryStructureLib.Structures
{
    public abstract class Statement
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public abstract List<InterpreterResult> Interpret(InterpreterService interpreterService);
    }
}
