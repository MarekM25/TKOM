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
        public abstract bool Equals(TokenType type);
        public abstract bool Equals(Keywords keyword);
        public abstract bool Equals(Operators oper);
    }
}
