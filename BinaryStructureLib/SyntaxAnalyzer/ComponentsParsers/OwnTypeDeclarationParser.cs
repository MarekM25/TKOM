using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class OwnTypeDeclarationParser
    {
        OwnTypeDeclaration ownTypeDeclaration = new OwnTypeDeclaration();

        public OwnTypeDeclaration ParseSimpleOwnType(TokenBase firstToken, TokenBase secondToken)
        {
            ownTypeDeclaration.TypeName = (string)firstToken.GetValue();
            ownTypeDeclaration.Name = (string)secondToken.GetValue();
            OwnTypeParametersList();
            return ownTypeDeclaration;
        }

        private void OwnTypeParametersList()
        {
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            if (ParserService.EqualsCurrentToken(new TokenOperator(Operators.ClosingCircleBracket)))
                ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            else
            {
                do
                {
                    ParserService.NextToken();
                    ownTypeDeclaration.Values.Add(ParserService.PreviousTokenValue());
                }
                while (ParserService.Accept(new TokenOperator(Operators.Comma)));
                ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            }
        }
    }
}
