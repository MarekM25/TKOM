using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.Statements
{
    public class VariableDeclaration :Statement
    {
        public Keywords Type { get; set; }

        public override List<InterpreterResult> Interpret(IInterpreterService interpreterService)
        {
            var result = new InterpreterResult();
            result.Name = this.Name;
            result.Size = this.Size;
            result.StructureName = interpreterService.GetCurrentStructureName(); 
            try
            {

                result.Value = interpreterService.ReadValue(Size);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InterpreterException(string.Format("Nieoczekiwany koniec pliku binarnego. Plik binarny jest za krótki. Koniec na zmiennej {0}",Name));
            }
            interpreterService.SetValue(Name, result.Value);
            return new List<InterpreterResult>() { result };
        }
    }
}
