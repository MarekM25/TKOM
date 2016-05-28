using BinaryStructureLib.Analyzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.Interpreter
{
    [TestFixture]
    public class ReadingValue
    {
        private byte[] byteArray = new byte[] { 1, 1, 0, 0 };
        
        [TestCase(8,ExpectedResult = 1)]
        [TestCase(16,ExpectedResult = 257)]
        [TestCase(32,ExpectedResult = 16842752)]
        public int SimpleReadValue(int size)
        {
            IInterpreterService interpreterService = new InterpreterService(null, byteArray);
            return interpreterService.ReadValue(size);
        }
    }
}
