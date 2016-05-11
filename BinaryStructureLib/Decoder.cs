using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Decoder
    {
        private string pattern;

        public Decoder(string pattern)
        {
            this.pattern = pattern;
        }

        public T Decode<T>(byte[] byteArray) where T :new()
        {
            return default(T);
        }
    }
}
