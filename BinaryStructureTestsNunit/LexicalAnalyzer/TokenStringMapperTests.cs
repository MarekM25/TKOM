using BinaryStructureLib;
using BinaryStructureLib.LexicalAnalayzer;
using BinaryStructureLib.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBinaryStructure.LexicalAnalyzer;

namespace BinaryStructureTestsNunit.LexicalAnalyzer
{
    [TestFixture]
    public class TokenStringMapperTests
    {
        [TestCase("begin",Keywords.Begin, ExpectedResult =true )]
        [TestCase("begin", Keywords.Else, ExpectedResult = false)]
        [TestCase("end", Keywords.End, ExpectedResult = true)]
        [TestCase("struct", Keywords.StructType, ExpectedResult = true)]
        [TestCase("int", Keywords.IntType, ExpectedResult = true)]
        [TestCase("if", Keywords.If, ExpectedResult = true)]
        [TestCase("else", Keywords.Else, ExpectedResult = true)]
        [TestCase("main", Keywords.Main, ExpectedResult = true)]
        [TestCase("true", Keywords.True, ExpectedResult = true)]
        [TestCase("false", Keywords.False, ExpectedResult = true)]
        [TestCase("bool", Keywords.BoolType, ExpectedResult = true)]
        public bool KeywordMap(string keywordString, Keywords keywordType)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(keywordString);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            return token.Equals(keywordType);
        }


        [TestCase("(", Operators.OpeningCircleBracket, ExpectedResult = true)]
        [TestCase(")", Operators.ClosingCircleBracket, ExpectedResult = true)]
        [TestCase("[", Operators.OpeningSquareBracket, ExpectedResult = true)]
        [TestCase("]", Operators.ClosingSquareBracket, ExpectedResult = true)]
        [TestCase(",", Operators.Comma, ExpectedResult = true)]
        [TestCase(";", Operators.Semicolon, ExpectedResult = true)]
        [TestCase("&", Operators.LogicAnd, ExpectedResult = true)]
        [TestCase("|", Operators.LogicOr, ExpectedResult = true)]
        [TestCase("!", Operators.LogicNegation, ExpectedResult = true)]
        [TestCase("=", Operators.LogicCompare, ExpectedResult = true)]
        [TestCase(">", Operators.Greater, ExpectedResult = true)]
        [TestCase("<", Operators.Smaller, ExpectedResult = true)]
        public bool OperatorMap(string operatorString, Operators operatorType)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(operatorString);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            return token.Equals(operatorType);
        }

        [TestCase("zmienna1",ExpectedResult = true)]
        [TestCase("begin",ExpectedResult = false)]
        public bool IsIdTypeMap(string inputString)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(inputString,isDigitsOnly:false,isDigitsOrLettersOnly:true);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            return token is TokenId;
        }

        [TestCase("zmienna1")]
        [TestCase("zmienna3")]
        public void IdValueMap(string inputString)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(inputString, isDigitsOnly: false, isDigitsOrLettersOnly: true);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            Assert.AreEqual(inputString,token.GetValue().ToString());
        }

        [TestCase("2314", ExpectedResult = true)]
        [TestCase("else", ExpectedResult = false)]
        public bool IsValueTypeMap(string inputValue)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(inputValue, isDigitsOnly: true, isDigitsOrLettersOnly: true);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            return token is TokenValue;
        }

        [TestCase("2314")]
        public void TokenValueCheckValue(string inputValue)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(inputValue, isDigitsOnly: true, isDigitsOrLettersOnly: true);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            var token = mapper.MapNextWord();
            Assert.AreEqual(inputValue.ToString(), token.GetValue().ToString());
        }

        [TestCase("_Fda")]        
        public void TokenValueCheckrValue(string inputValue)
        {
            INextTokenStringReader nextTokenStringReader = new NextStringTokenReaderMock(inputValue, isDigitsOnly: false, isDigitsOrLettersOnly: false);
            var mapper = new TokenStringMapper(nextTokenStringReader);
            Assert.Throws<LexicalAnalyzerException>(()=>mapper.MapNextWord());
        }
    }
}
