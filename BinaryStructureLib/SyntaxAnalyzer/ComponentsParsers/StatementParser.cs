using BinaryStructureLib.Structures;
using BinaryStructureLib.Structures.Statements;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class StatementParser
    {
        private Statement statement;

        private TokenBase firstToken;
        private TokenBase secondToken;
        private TokenBase thirdToken;


        public Statement Parse()
        {
            firstToken = ParserService.CurrentToken();
            if (firstToken.Equals(Keywords.If))
                ParseIfStatement();
            else
            {
                secondToken = ParserService.NextToken();
                thirdToken = ParserService.NextToken();
                if (ParserService.Accept(new TokenOperator(Operators.OpeningSquareBracket)))
                    ParsetArrayType();
                else
                    ParseSimpleType();
                ParserService.Expect(new TokenOperator(Operators.Semicolon));
            }
            return statement;
        }

        private void ParseIfStatement()
        {
            var ifStatementParser = new IfStatementParser();
            statement = ifStatementParser.Parse();
        }


        private void ParseSimpleType()
        {
            if (firstToken.Equals(Keywords.IntType))
                ParseSimpleIntType();
            else
                ParseSimpleOwnType();
        }

        private void ParseSimpleOwnType()
        {
            OwnTypeDeclarationParser ownTypeDeclarationParser = new OwnTypeDeclarationParser();
            statement = ownTypeDeclarationParser.ParseSimpleOwnType(firstToken,secondToken);
        }

        private void ParseSimpleIntType()
        {
            VariableDeclaration varDeclaration = new VariableDeclaration();
            varDeclaration.Type = Keywords.IntType;
            varDeclaration.Name = (string)secondToken.GetValue();
            ParserService.Expect(new TokenKeyword(Keywords.Size));
            ParserService.Expect(new TokenValue());
            varDeclaration.Size = (int)ParserService.PreviousTokenValue();
            statement = varDeclaration;
        }

        private void ParsetArrayType()
        {
            if (firstToken.Equals(Keywords.IntType))
                ParseArrayIntType();
            else
                ParseArrayOwnType();
        }

        private void ParseArrayOwnType()
        {
            OwnTypeDeclaration ownTypeDeclaration = new OwnTypeDeclaration();
            ownTypeDeclaration.TypeName = (string)firstToken.GetValue();
            ownTypeDeclaration.Name = (string)secondToken.GetValue();
            ParserService.Expect(new TokenKeyword(Keywords.Size));
            ParserService.Expect(new TokenValue());
            ownTypeDeclaration.Size = (int)ParserService.PreviousTokenValue();
            //GetParameterLists
            statement = ownTypeDeclaration;
        }

        private void ParseArrayIntType()
        {
            ArrayVariableDeclaration arrayDeclaration = new ArrayVariableDeclaration();
            arrayDeclaration.Type = Keywords.IntType;
            arrayDeclaration.Name = (string)secondToken.GetValue();
            if (ParserService.Accept(new TokenValue()))
            {
                arrayDeclaration.Length = (int)ParserService.PreviousTokenValue();
                arrayDeclaration.HasLengthValue = true;
            }
            else if (ParserService.Accept(new TokenId()))
            {
                arrayDeclaration.LengthVariableName = (string)ParserService.PreviousTokenValue();
                arrayDeclaration.HasLengthValue = false;
            }
            ParserService.Expect(new TokenOperator(Operators.ClosingSquareBracket));
            ParserService.Expect(new TokenKeyword(Keywords.Size));
            ParserService.Expect(new TokenValue());
            arrayDeclaration.Size = (int)ParserService.PreviousTokenValue();
            statement = arrayDeclaration;
        }
    }
}
