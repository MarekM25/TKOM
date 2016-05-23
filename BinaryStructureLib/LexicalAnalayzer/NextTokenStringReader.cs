using BinaryStructureLib.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.LexicalAnalayzer
{
    public class NextTokenStringReader : INextTokenStringReader
    {
        private bool isCurrentDigitsOnly = true;
        private bool isCurrentLetterOrDigitOnly = true;
        private bool isCurrentOperator = false;


        private string currentTokenString;
        private bool peekWhitespace = false;
        private bool endOfStream = false;
        private bool wasOperator = false;

        private StreamReader streamReader;

        bool INextTokenStringReader.IsCurrentDigitsOnly
        {
            get
            {
                return isCurrentDigitsOnly;
            }
        }

        bool INextTokenStringReader.IsCurrentDigitsOrLettersOnly
        {
            get
            {
                return isCurrentLetterOrDigitOnly;
            }
        }

        public bool EndOfStream
        {
            get
            {
                return endOfStream;
            }
        }

        public NextTokenStringReader(StreamReader streamReader)
        {
            this.streamReader = streamReader;
        }

        public string ReadNextTokenStringWord()
        {
            isCurrentDigitsOnly = true;
            isCurrentLetterOrDigitOnly = true;
            InitializeNextTokenString();
            string returnString = currentTokenString;
            CleanUp();
            return returnString;
        }

        private void CleanUp()
        {
            currentTokenString = String.Empty;
            peekWhitespace = false;
        }

        private void InitializeNextTokenString()
        {
            while (!CheckIfWordEnd())
            {
                char readChar = (char)streamReader.Read();
                currentTokenString += readChar.ToString();
                isCurrentDigitsOnly = isCurrentDigitsOnly && Char.IsDigit(readChar);
                isCurrentLetterOrDigitOnly = isCurrentLetterOrDigitOnly && Char.IsLetterOrDigit(readChar);
            }
        }


        private bool CheckIfWordEnd()
        {
            bool wasOperator = false;
            if (isCurrentOperator)
            {
                currentTokenString += (char)streamReader.Read();
                wasOperator = true;
            }
            char nextChar = LookAhead();
            isCurrentOperator = nextChar.IsOperatorChar();
            return endOfStream || peekWhitespace || nextChar.IsOperatorChar() || wasOperator;
        }

        private char LookAhead()
        {
            int peekChar = streamReader.Peek();
            char nextChar = ' ';
            if (peekChar == -1)
                endOfStream = true;
            else
            {
                nextChar = (char)peekChar;
                if (Char.IsWhiteSpace(nextChar))
                {
                    peekWhitespace = true;
                    streamReader.SkipWhitespace();
                    nextChar = (char)streamReader.Peek();
                }
            }
            return nextChar;
        }
    }
}
