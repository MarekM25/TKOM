using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Token : IEquatable<Token>
    {
        private TokenType type;
        private object value;

        public Token(TokenType type, object value) : this()
        {
            this.type = type;
            this.value = value;
        }

        public Token()
        {
        }

        public object SomePropertyName
        {
            get
            {
                return SomePropertyImpl();
            }
        }
        protected virtual object SomePropertyImpl()
        {
            // base-class version
            return null;
        }

        public TokenType Type { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("TokenType: {0}, Value: {1}",
                Type.ToString(),
                Value.ToString());
        }

        public bool Equals(Keywords keyword)
        {
            return this.Type == TokenType.Keyword && this.Value.Equals(keyword);
        }

        public bool Equals(Operators oper)
        {
            return this.Type == TokenType.Operator && this.Value.Equals(oper);
        }

        public bool Equals(Token other)
        {
            if (this.Type == TokenType.Keyword || this.Type == TokenType.Operator)
                return this.Type == other.Type && this.Value.Equals(other.Value);
            else
                return this.Type == other.Type;
        }
    }
}
