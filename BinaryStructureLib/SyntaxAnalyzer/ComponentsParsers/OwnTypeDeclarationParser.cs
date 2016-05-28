using BinaryStructureLib.Analyzer;
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
        private ParserService parserService;

        public OwnTypeDeclarationParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public OwnTypeDeclaration ParseSimpleOwnType(TokenBase firstToken, TokenBase secondToken)
        {
            ownTypeDeclaration.TypeName = (string)firstToken.GetValue();
            var variableName = (string)secondToken.GetValue();
            parserService.AddNewVariableName(variableName);
            ownTypeDeclaration.Name = variableName;
            OwnTypeParametersList();
            return ownTypeDeclaration;
        }

        private void OwnTypeParametersList()
        {
            parserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            if (parserService.EqualsCurrentToken(new TokenOperator(Operators.ClosingCircleBracket)))
                parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            else
            {
                do
                {
                    parserService.NextToken();
                    ownTypeDeclaration.Values.Add(parserService.PreviousTokenValue());
                }
                while (parserService.Accept(new TokenOperator(Operators.Comma)));
                parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            }
        }
    }
}
