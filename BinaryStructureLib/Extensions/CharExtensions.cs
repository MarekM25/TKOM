using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public static class CharExtensions
    {
        public static char[] tokenWordChars = new char[] { ';', '(', ')', '[', ']', ',', '&','|','=', '!'};
        public static bool IsTokenWordChar(this char character)
        {
            return tokenWordChars.Contains(character);
        }
    }
}
