using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Exceptions;
using BinaryStructureLib.LexicalAnalayzer;
using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Compiler
    {
        StreamReader stream;
        public Compiler(StreamReader stream)
        {
            this.stream = stream;
        }

        public BinaryStructure Result { get; set; }
        public string Error { get; set; }

        public bool Compile()
        {
            try
            {
                ILexicalAnalyzer lexicalAnalyzer = new Scanner(stream);
                lexicalAnalyzer.Init();
                IParser parser = new Parser(lexicalAnalyzer);
                Result = parser.Parse();
            }
            catch (CompilerException compilerException)
            {
                Error = compilerException.Message;
                return false;
            }
            catch (Exception ex)
            {
                Error = "Błąd wewnętrzny kompilatora: "+ex.Message;
                return false;
            }
            return true;

        }
    }
}
