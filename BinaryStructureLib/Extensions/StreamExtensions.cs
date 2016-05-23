using BinaryStructureLib.Extensions;
using System;
using System.IO;
using System.Text;

namespace BinaryStructureLib
{
    public static class StreamExtensions
    {
        public static bool ReadCharFromStream(this Stream stream, out char character)
        {
            var bytes = new byte[1];
            int bytesRead = stream.Read(bytes, 0, 1);
            character = (char)bytes[0];
            return bytesRead == 1;
        }

        public static bool FirstNotWhiteSpaceChar(this Stream stream, out char character)
        {
            bool streamHasChar = stream.ReadCharFromStream(out character);
            while (char.IsWhiteSpace(character))
            {
                streamHasChar = stream.ReadCharFromStream(out character);
            }
            return streamHasChar;
        }

        public static bool NextWord(this Stream stream, out string nextWord)
        {
            StringBuilder builder = new StringBuilder();
            char c;
            bool streamHasCharacter = stream.FirstNotWhiteSpaceChar(out c);
            if (c.IsTokenWordChar())
                builder.Append(c.ToString());
            else
                while (!Char.IsWhiteSpace(c))
                {
                    if (streamHasCharacter == false) break;
                    if (c.IsTokenWordChar())
                    {
                        stream.Seek(-1, SeekOrigin.Current); //peek na stream
                        break;
                    }
                    builder.Append(c.ToString());
                    streamHasCharacter = stream.ReadCharFromStream(out c);

                }
            nextWord = builder.ToString();
            if (!streamHasCharacter) // wjedną linijkę 
                return false;
            return true;
        }
    }
}

