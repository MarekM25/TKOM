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

        public TokenGenericBase()
        {
        }

        public override object GetValue()
        {
            return Value;
        }

        public override bool Equals(TokenBase other)
        {
            return this.GetType() == other.GetType();
        }

        public override bool Equals(TokenType type)
        {
            if (TokenType.Id == type)
                return this is TokenId;
            if (TokenType.Keyword == type)
                return this is TokenKeyword;
            if (TokenType.Operator == type)
                return this is TokenOperator;
            return this is TokenValue;
        }

        public override bool Equals(Keywords keyword)
        {
            return this is TokenKeyword && (this as TokenKeyword).Value == keyword;
        }

        public override bool Equals(Operators oper)
        {
            return this is TokenOperator && (this as TokenOperator).Value == oper;
        }

        public override string ToString()
        {
            return string.Format("TokenType: {0}, Value: {1}",
                this.GetType().Name,
                Value.ToString());
        }
    }
}
