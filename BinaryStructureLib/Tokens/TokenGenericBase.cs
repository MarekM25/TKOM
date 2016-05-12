using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Tokens
{
    public abstract class TokenGenericBase<T> : TokenBase
    {
        public T Value { get; set; }

        public TokenGenericBase(T value)
        {
            this.Value = value;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override bool Equals(TokenBase other)
        {
            return this.GetType() == other.GetType();
        }
    }
}
