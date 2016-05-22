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

        private void DecodeSingleStatemnet(Statement test)
        {
            Console.WriteLine("Zdekodowano {0}",test.Name);
            Console.WriteLine(Convert.ToInt32(byteArray[0]));
        }

        public void Decode() 
        {
            DecodeSingleStatemnet(binaryStructure.mainStructure.statements[0]);
        }
    }
}
