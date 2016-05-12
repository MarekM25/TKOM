using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Tokens
{
    public class TokenValue : TokenGenericBase<int>
    {
        public TokenValue(int value) : base(value) { }
    }
}
