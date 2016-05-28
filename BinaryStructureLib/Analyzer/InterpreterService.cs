using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Structures.Statements;

namespace BinaryStructureLib.Analyzer
{
    public class InterpreterService : IInterpreterService
    {
        private BinaryStructure binaryStructure;
        private int currentByte = 0;
        private byte[] fileByteArray;


        public InterpreterService(BinaryStructure binaryStructure,byte[] fileByteArray)
        {
            this.binaryStructure = binaryStructure;
            this.fileByteArray = fileByteArray;
        }

        public void InterpretStructure(OwnTypeDeclaration ownTypeDeclaration)
        {
            throw new NotImplementedException();
        }

        public int ReadValue(int size)
        {
            int amountOfBytes = size / 8;
            var smallPortion = fileByteArray.Skip(currentByte).Take(amountOfBytes).ToArray();
            int returnValue = ConvertToInt(amountOfBytes,smallPortion);
            currentByte += amountOfBytes;
            return returnValue;
        }


        private int ConvertToInt(int numberOfBytes, byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);
            switch (numberOfBytes)
            {
                case 1:
                    return array[0];
                case 2:
                    return BitConverter.ToInt16(array, 0);
                case 4:
                    return BitConverter.ToInt32(array, 0);
            }
            throw new NotImplementedException();
        }
    }
}
