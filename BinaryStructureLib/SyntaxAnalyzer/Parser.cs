using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public partial class Parser : IParser
    {
        ILexicalAnalyzer lexicalAnalyzer;
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

        private void StructDeclarations()
        {
            if (Accept(Keywords.StructType))
            {
               // Expect()
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

        //private bool Accept(Operators oper)
        //{
        //    return Accept(new Token(TokenType.Operator, (object)oper));
        //}

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
            if (Accept(keyword))
                return true;
            //Parse exception//error("expect: unexpected symbol");
            return false;
        }

    }
}
