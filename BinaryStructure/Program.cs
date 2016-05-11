using BinaryStructureLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructure
{
    class Program
    {
        private static void coding()
        {
            string pattern = @"struct.Count = 10
                            struct.Contents = 
                            {
                            int.Length = 17
                            int.Length = 17
                            }
                            ";
            ZipCodes zipCode = new ZipCodes()
            {
                ZipCodeFrom = 11111,
                ZipCodeTo = 12111
            };
            ZipCodes[] zipCodes = new ZipCodes[10];

            //Kodowanie
            Coder coder = new Coder(pattern);
            var byteArray = coder.GenerateByteArray<ZipCodes>(zipCode);

            //Dekodowanie
            BinaryStructureLib.Decoder decoder = new BinaryStructureLib.Decoder(pattern);
            decoder.Decode<ZipCodes>(byteArray);
        }

        static void Main(string[] args)
        {
            if (args == null || args.Count() == 0)
                Console.WriteLine("Zbyt mało argumentów wejściowych");
            if (args.Count() == 1)
            {
                var stream = System.IO.File.OpenRead(args[0]);
                Compiler compiler = new Compiler(stream);
                bool success = compiler.Compile();
                if (success == false)
                {
                    Console.WriteLine("Błąd podczas kompilacji.");
                    Console.WriteLine(compiler.Error);
                }
            }
        }
    }
}
