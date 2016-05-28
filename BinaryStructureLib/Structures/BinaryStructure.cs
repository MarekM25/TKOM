using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures
{
    
    public class BinaryStructure
    {
        public List<Structure> stuctDeclarations = new List<Structure>();

        public MainStructure mainStructure = new MainStructure();


        public List<InterpreterResult> Interpret(byte[] fileByteArray)
        {
            InterpreterService interpreterService = new InterpreterService(this, fileByteArray);
            List<InterpreterResult> results = new List<InterpreterResult>();
            foreach (var statement in mainStructure.Statements)
            {
                results.AddRange(statement.Interpret(interpreterService));
            }
            return results;
        }
    }
}
