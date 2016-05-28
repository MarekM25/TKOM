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
        void InterpretStructure(OwnTypeDeclaration ownTypeDeclaration);
    }
}
