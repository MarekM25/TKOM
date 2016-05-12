using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Tokens
{
    public class TokenKeyword : TokenGenericBase<Keywords>
    {
        public TokenKeyword(Keywords value) : base(value) {}

        public override bool Equals(TokenBase other)
        {
            return base.Equals(other) && this.Value == (other as TokenKeyword).Value;
        }
    }
}