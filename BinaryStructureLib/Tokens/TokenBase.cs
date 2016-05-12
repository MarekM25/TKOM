using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Tokens
{
    public abstract class TokenBase :IEquatable<TokenBase>
    { 
        public abstract object GetValue();
        public abstract bool Equals(TokenBase other);
    }
}
