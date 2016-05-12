using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer
{
    public class ParserService
    {
        private static ILexicalAnalyzer lexicalAnalyzer;

        public static void Initialize(ILexicalAnalyzer lexicalAnalyzer)
        {
            ParserService.lexicalAnalyzer = lexicalAnalyzer;
        }

        public static bool Accept<T>(T token) where T : new()
        {
            return lexicalAnalyzer.CurrentToken.Equals(token);
        }

        public static bool TestAccept(Keywords keyword)
        {
            return lexicalAnalyzer.CurrentToken.Equals(keyword);
        }

        public static bool Expect<T>(T token) where T : new()
        {
            if (Accept(token))
                return true;
            //Parse exception//error("expect: unexpected symbol");
            return false;
        }
    }
}
