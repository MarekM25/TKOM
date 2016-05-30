using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Exceptions;
using BinaryStructureLib.Structures.Statements;
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
                var statementInterpretResult = statement.Interpret(interpreterService);
                if (statementInterpretResult!=null)
                    results.AddRange(statementInterpretResult);
            }
            return results;
        }


        public Structure InitStructure(OwnTypeDeclaration ownTypeDeclaration)
        {
            var structure = stuctDeclarations.Where(x => x.Name == ownTypeDeclaration.TypeName).FirstOrDefault();
            if (structure == null)
                throw new InterpreterException(string.Format("Nie znaleziono definicji struktury o typie {0}.", ownTypeDeclaration.TypeName));
            if (ownTypeDeclaration.Values.Count() != structure.Parameters.Count())
                throw new InterpreterException(string.Format("Niepoprawna ilość parameterów w wywołaniu struktury o typie {0}.", ownTypeDeclaration.TypeName));
            for (int i=0;i<structure.Parameters.Count();++i)
            {
                structure.Parameters[i].Value = ownTypeDeclaration.Values[i];
                structure.Variables[structure.Parameters[i].Name] = ownTypeDeclaration.Values[i];
            }
            return structure;
        }
    }
}
