using BinaryStructureLib.LexicalAnalayzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBinaryStructure.LexicalAnalyzer
{
    public class NextStringTokenReaderMock : INextTokenStringReader
    {
        private string currentWord;
        private bool isDigitsOnly;
        private bool isDigitsOrLettersOnly;

        public NextStringTokenReaderMock(string currentWord)
        {
            this.currentWord = currentWord;
        }

        public NextStringTokenReaderMock(string currentWord, bool isDigitsOnly, bool isDigitsOrLettersOnly)
        {
            this.currentWord = currentWord;
            this.isDigitsOnly = isDigitsOnly;
            this.isDigitsOrLettersOnly = isDigitsOrLettersOnly;
        }

        public bool EndOfStream
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsCurrentDigitsOnly
        {
            get
            {
                return isDigitsOnly;
            }
        }

        public bool IsCurrentDigitsOrLettersOnly
        {
            get
            {
                return isDigitsOrLettersOnly;
            }
        }

        public int LineCounter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ReadNextTokenStringWord()
        {
            return currentWord;
        }
    }
}
