using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Tokens
{
    public class TokenId : TokenGenericBase<string>
    {
        public TokenId(string value) : base(value) { }
    }
}
