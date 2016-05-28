using BinaryStructureLib;
using BinaryStructureLib.Analyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructure
{
    class Program
    {
        public static void PrintInterpreterResult(List<InterpreterResult> interpreterResults)
        {
            foreach (var result in interpreterResults)
            {
                Console.WriteLine(string.Format("Zdekodowano zmienną o nazwie {0}, rozmiarze {1} i wartości {2}", result.Name, result.Size, result.Value));
            }
        }

        static void Main(string[] args)
        {
            BinaryStructureLib.Structures.BinaryStructure test = new BinaryStructureLib.Structures.BinaryStructure();
            if (args == null || args.Count() == 0)
                Console.WriteLine("Zbyt mało argumentów wejściowych");
            if (args.Count() == 1)
            {
                var stream = System.IO.File.OpenRead(args[0]);
                Compiler compiler = new Compiler(new StreamReader(stream));
                bool success = compiler.Compile();
                if (success == false)
                {
                    Console.WriteLine("Błąd podczas kompilacji.");
                    Console.WriteLine(compiler.Error);
                }
                var results = compiler.Result.Interpret(File.ReadAllBytes("binary.bin"));
                PrintInterpreterResult(results);
            }
        }
    }
}
