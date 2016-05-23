using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Extensions
{
    public static class CharExtensions
    {
        public static char[] operatorsChars = new char[] { ';', '(', ')', '[', ']', ',', '&','|','=', '!','<','>'};
        public static bool IsTokenWordChar(this char character)
        {
            return operatorsChars.Contains(character);
        }

        public static bool IsOperatorChar(this char character)
        {
            return operatorsChars.Contains(character);
        }
    }
}
