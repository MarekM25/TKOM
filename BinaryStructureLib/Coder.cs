using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Coder
    {
        private string pattern;

        public Coder(string pattern)
        {
            this.pattern = pattern;
        }

        public Byte[] GenerateByteArray<T>(T toCode) where T : new()
        {
            return null;
        }
    }
}
