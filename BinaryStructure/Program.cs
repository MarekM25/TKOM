using BinaryStructureLib;
using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Exceptions;
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
        private static void PrintInterpreterResult(List<InterpreterResult> interpreterResults)
        {
            foreach (var result in interpreterResults)
            {
                Console.WriteLine(string.Format("Zdekodowano zmienna o nazwie {0}, rozmiarze {1} i wartosci {2} w strukturze o typie {3}", result.Name, result.Size, result.Value, result.StructureName));
            }
        }

        private static void Interpret(string filePath, BinaryStructureLib.Structures.BinaryStructure binaryStructure)
        {
            try
            {
                var results = binaryStructure.Interpret(File.ReadAllBytes(filePath));
                PrintInterpreterResult(results);
            }
            catch (InterpreterException interpreterException)
            {
                Console.WriteLine(interpreterException.Message);
            }
            }

        static void Main(string[] args)
        {
            BinaryStructureLib.Structures.BinaryStructure test = new BinaryStructureLib.Structures.BinaryStructure();
            if (args == null || args.Count() != 2)
                Console.WriteLine("Niepoprawna ilosc argumentów wejsciowych");
            if (args.Count() == 2)
            {
                var stream = System.IO.File.OpenRead(args[0]);
                Compiler compiler = new Compiler(new StreamReader(stream));
                bool success = compiler.Compile();
                if (success == false)
                {
                    Console.WriteLine("Blad podczas kompilacji.");
                    Console.WriteLine(compiler.Error);
                }
                else
                    Interpret(args[1], compiler.Result);
            }
        }
    }
}
