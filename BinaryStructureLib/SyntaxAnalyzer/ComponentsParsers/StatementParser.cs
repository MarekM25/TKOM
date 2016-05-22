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
        private static Statement statement;

        private static TokenBase firstToken;
        private static TokenBase secondToken;
        private static TokenBase thirdToken;


        public static Statement Parse()
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
            }
            ParserService.Expect(new TokenOperator(Operators.Semicolon));
            return statement;
        }

        private static void ParseIfStatement()
        {
            statement = IfStatementParser.Parse();
        }


        private static void ParseSimpleType()
        {
            if (firstToken.Equals(Keywords.IntType))
                ParseSimpleIntType();
            else
                ParseSimpleOwnType();
        }

        private static void ParseSimpleOwnType()
        {
            OwnTypeDeclaration ownTypeDeclaration = new OwnTypeDeclaration();
            ownTypeDeclaration.TypeName = (string)firstToken.GetValue();
            ownTypeDeclaration.Name = (string)secondToken.GetValue();
            if (!ParserService.Accept(new TokenKeyword(Keywords.Size)))
                throw new NotImplementedException();
            ParserService.Expect(new TokenValue());
            ownTypeDeclaration.Size = (int)ParserService.PreviousTokenValue();
            statement = ownTypeDeclaration;
        }

        private static void ParseSimpleIntType()
        {
            VariableDeclaration varDeclaration = new VariableDeclaration();
            varDeclaration.Type = Keywords.IntType;
            varDeclaration.Name = (string)secondToken.GetValue();
            if (!ParserService.Accept(new TokenKeyword(Keywords.Size)))
                throw new NotImplementedException();
            ParserService.Expect(new TokenValue());
            varDeclaration.Size = (int)ParserService.PreviousTokenValue();
            statement = varDeclaration;
        }

        private static void ParsetArrayType()
        {
            if (firstToken.Equals(Keywords.IntType))
                ParseArrayIntType();
            else
                ParseArrayOwnType();
        }

        private static void ParseArrayOwnType()
        {
            OwnTypeDeclaration ownTypeDeclaration = new OwnTypeDeclaration();
            ownTypeDeclaration.TypeName = (string)firstToken.GetValue();
            ownTypeDeclaration.Name = (string)secondToken.GetValue();
            if (!ParserService.Accept(new TokenKeyword(Keywords.Size)))
                throw new NotImplementedException();
            ParserService.Expect(new TokenValue());
            ownTypeDeclaration.Size = (int)ParserService.PreviousTokenValue();
            //GetParameterLists
            statement = ownTypeDeclaration;
        }

        private static void ParseArrayIntType()
        {
            ArrayVariableDeclaration arrayDeclaration = new ArrayVariableDeclaration();
            arrayDeclaration.Type = Keywords.IntType;
            arrayDeclaration.Name = (string)secondToken.GetValue();
            ParserService.Expect(new TokenValue());
            arrayDeclaration.Length = (int)ParserService.PreviousTokenValue();
            ParserService.Expect(new TokenOperator(Operators.ClosingSquareBracket));
            ParserService.Expect(new TokenKeyword(Keywords.Size));
            ParserService.Expect(new TokenValue());
            arrayDeclaration.Size = (int)ParserService.PreviousTokenValue();
            statement = arrayDeclaration;
        }
    }
}
