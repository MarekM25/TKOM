using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Exceptions
{
    public class InterpreterException : Exception
    {
        public InterpreterException(string message) : base(message) { }
    }
}
