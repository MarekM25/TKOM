using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Analyzer
{
    public class InterpreterService : IInterpreterService
    {
        private BinaryStructure binaryStructure;
        private Structure currentStructure;

        public void TestMethod()
        {
            var structure = new Structure();
            binaryStructure.stuctDeclarations.Add(structure);
            binaryStructure.stuctDeclarations[0].Name = "Test1";
            currentStructure = binaryStructure.stuctDeclarations[0];
            currentStructure.Name = "Test2";
            System.Diagnostics.Debug.WriteLine(binaryStructure.stuctDeclarations[0].Name);

        }

        public void SetVariableValue(string variableName)
        {

        }

        public void GetVariableValue(string variableName)
        {

        }

        public void Init(BinaryStructure binaryStructure)
        {
            this.binaryStructure = binaryStructure;
        }
    }
}
