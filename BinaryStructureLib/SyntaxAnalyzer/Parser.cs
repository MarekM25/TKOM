using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class Parser : IParser
    {
        public ILexicalAnalyzer lexicalAnalyzer;

        public Parser(ILexicalAnalyzer lexicalAnalyzer)
        {
            this.lexicalAnalyzer = lexicalAnalyzer;
        }

        public BinaryStructure Parse()
        {
            StructDeclarations();
            MainStructure();
            while (lexicalAnalyzer.HasTokens())
            {
                lexicalAnalyzer.GetNextToken();
            }
            return null;
        }

        private void ParameterLists()
        {
            Expect(Operators.OpeningCircleBracket);
            do
            {
                Parameter();
            } while (Accept(Operators.Comma);
            Expect(Operators.ClosingCircleBracket);
        }

        private void Parameter()
        {

        }

        private void StructDeclarations()
        {
            if (Accept(Keywords.StructType))
            {
                ParameterLists();
                
                
                Expect()
                if (Accept(Keywords.Begin))
                {

                    //loop statements
                    if (Accept(Keywords.End))
                    {

                    }
                }
            }
        }

        private void MainStructure()
        {

        }

        private bool Accept(Operators oper)
        {
            return Accept(new Token(TokenType.Operator, (object)oper));
        }

        private bool Accept(TokenType type)
        {
            return Accept(new Token(type, null));
        }

        private bool Accept(Keywords keyword)
        {
            return Accept(new Token(TokenType.Keyword, (object)keyword));
        }

        private bool Accept(Token token)
        {
            return token.Equals(lexicalAnalyzer.CurrentToken);
        }

        private bool Expect(Token token)
        {
            if (Accept(token))
                return true;
            //Parse exception//error("expect: unexpected symbol");
            return false;
        }

        private bool Expect(Keywords keyword)
        {
            return Expect(new Token(TokenType.Keyword, keyword));
        }

        private bool Expect(Operators operators)
        {
            return Expect(new Token(TokenType.Operator, operators));
        }
    }
}
