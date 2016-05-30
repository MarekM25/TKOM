﻿using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.Exceptions;

namespace BinaryStructureLib.Analyzer
{
    public class InterpreterService : IInterpreterService
    {
        private BinaryStructure binaryStructure;
        private int currentByte = 0;
        private byte[] fileByteArray;
        public StructureBase currentStructure;

        public InterpreterService(BinaryStructure binaryStructure,byte[] fileByteArray)
        {
            this.binaryStructure = binaryStructure;
            this.fileByteArray = fileByteArray;
        }

        public List<InterpreterResult> InterpretStructure(OwnTypeDeclaration ownTypeDeclaration)
        {
            var structure = binaryStructure.InitStructure(ownTypeDeclaration);
            currentStructure = structure;
            return structure.Interpret(this);
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
            throw new InterpreterException(string.Format("Nieobsłygiwany rozmiar zmiennej {0}.", numberOfBytes));
        }


        public object GetValue(string variableName)
        {
            if (currentStructure.Variables.ContainsKey(variableName))
                return currentStructure.Variables[variableName];
            throw new InterpreterException(string.Format("Nie można pobrać wartości zmiennej o nazwie {0}", variableName));
        }

        public void SetValue(string variableName, object value)
        {
            if (currentStructure.Variables.ContainsKey(variableName))
                currentStructure.Variables[variableName] = value;
            else
                throw new InterpreterException(string.Format("Nie można przypisać wartości zmiennej o nazwie {0}", variableName));
        }
    }
}
