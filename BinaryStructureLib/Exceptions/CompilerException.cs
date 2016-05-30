using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Exceptions
{
    public class CompilerException : Exception
    {

        public CompilerException() : base() { }

        public CompilerException(string v) : base(v) { }
    }
}
