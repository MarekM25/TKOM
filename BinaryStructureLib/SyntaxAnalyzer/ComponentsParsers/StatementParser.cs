using BinaryStructureLib.Analyzer;
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
        private ParserService parserService;

        public StatementParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public Statement Parse()
        {
            firstToken = parserService.CurrentToken();
            if (firstToken.Equals(Keywords.If))
                ParseIfStatement();
            else
            {
                secondToken = parserService.NextToken();
                thirdToken = parserService.NextToken();
                if (parserService.Accept(new TokenOperator(Operators.OpeningSquareBracket)))
                    ParsetArrayType();
                else
                    ParseSimpleType();
                parserService.Expect(new TokenOperator(Operators.Semicolon));
            }
            return statement;
        }

        private void ParseIfStatement()
        {
            var ifStatementParser = new IfStatementParser(parserService);
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
            OwnTypeDeclarationParser ownTypeDeclarationParser = new OwnTypeDeclarationParser(parserService);
            statement = ownTypeDeclarationParser.ParseSimpleOwnType(firstToken,secondToken);
        }

        private void ParseSimpleIntType()
        {
            VariableDeclaration varDeclaration = new VariableDeclaration();
            varDeclaration.Type = Keywords.IntType;
            var variableName = (string)secondToken.GetValue();
            parserService.AddNewVariableName();
            varDeclaration.Name = variableName;
            parserService.Expect(new TokenKeyword(Keywords.Size));
            parserService.Expect(new TokenValue());
            varDeclaration.Size = (int)parserService.PreviousTokenValue();
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
            parserService.Expect(new TokenKeyword(Keywords.Size));
            parserService.Expect(new TokenValue());
            ownTypeDeclaration.Size = (int)parserService.PreviousTokenValue();
            //GetParameterLists
            statement = ownTypeDeclaration;
        }

        private void ParseArrayIntType()
        {
            ArrayVariableDeclaration arrayDeclaration = new ArrayVariableDeclaration();
            arrayDeclaration.Type = Keywords.IntType;
            arrayDeclaration.Name = (string)secondToken.GetValue();
            if (parserService.Accept(new TokenValue()))
            {
                arrayDeclaration.Length = (int)parserService.PreviousTokenValue();
                arrayDeclaration.HasLengthValue = true;
            }
            else if (parserService.Accept(new TokenId()))
            {
                arrayDeclaration.LengthVariableName = (string)parserService.PreviousTokenValue();
                arrayDeclaration.HasLengthValue = false;
            }
            parserService.Expect(new TokenOperator(Operators.ClosingSquareBracket));
            parserService.Expect(new TokenKeyword(Keywords.Size));
            parserService.Expect(new TokenValue());
            arrayDeclaration.Size = (int)parserService.PreviousTokenValue();
            statement = arrayDeclaration;
        }
    }
}
