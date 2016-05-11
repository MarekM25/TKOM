using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public struct Token : IEquatable<Token>
    {
        private TokenType keyword;
        private object value;

        public Token(TokenType keyword, object value) : this()
        {
            this.keyword = keyword;
            this.value = value;
        }

        public TokenType Type { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("TokenType: {0}, Value: {1}",
                Type.ToString(),
                Value.ToString());
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
