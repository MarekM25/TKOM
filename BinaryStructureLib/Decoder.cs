using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Decoder
    {
        private BinaryStructure binaryStructure;
        private byte[] byteArray;

        public Decoder(BinaryStructure binaryStructure, byte[] byteArray)
        {
            this.binaryStructure = binaryStructure;
            this.byteArray = byteArray;
        }

        private void DecodeSingleResult(InterpreterResult interpreterResult)
        {
            Console.WriteLine(string.Format("Zdekodowano zmienną o nazwie {0}, rozmiarze {1}",interpreterResult.Name,interpreterResult.Size));
        }

        public void Decode() 
        {
            //var interpreterResults = binaryStructure.Interpret();
            //foreach (var interpreterResult in interpreterResults)
            //{
            //    DecodeSingleResult(interpreterResult);
            //}
        }
    }
}
