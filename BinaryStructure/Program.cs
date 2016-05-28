﻿using BinaryStructureLib;
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
        static void Main(string[] args)
        {
            BinaryStructureLib.Structures.BinaryStructure test = new BinaryStructureLib.Structures.BinaryStructure();
            InterpreterService interpreter = new InterpreterService(test);
            interpreter.TestMethod();
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

                BinaryStructureLib.Decoder decoder = new BinaryStructureLib.Decoder(compiler.Result, File.ReadAllBytes("binary.bin"));
                decoder.Decode();
            }
        }
    }
}
