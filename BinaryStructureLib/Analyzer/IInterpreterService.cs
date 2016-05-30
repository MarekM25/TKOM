using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Structures.Statements;

namespace BinaryStructureLib.Analyzer
{
    public interface IInterpreterService
    {
        int ReadValue(int size);
        List<InterpreterResult> InterpretStructure(OwnTypeDeclaration ownTypeDeclaration);
        object GetValue(string variableName);
        void SetValue(string variableName, object value);
    }
}
