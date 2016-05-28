﻿using BinaryStructureLib;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.SyntaxAnalyzer
{
    class ParameterListParserTest
    {
        private TokenBase[] zeroParameters = new TokenBase[]
    {  new TokenOperator(Operators.OpeningCircleBracket),
        new TokenOperator(Operators.ClosingCircleBracket)};


        private TokenBase[] oneParameter = new TokenBase[]
{  new TokenOperator(Operators.OpeningCircleBracket),
    new TokenKeyword(Keywords.IntType),
    new TokenId("parameter1"),
        new TokenOperator(Operators.ClosingCircleBracket)};

        private TokenBase[] twoParameter = new TokenBase[]
{  new TokenOperator(Operators.OpeningCircleBracket),
    new TokenKeyword(Keywords.IntType),
    new TokenId("parameter1"),
    new TokenOperator(Operators.Comma),
        new TokenKeyword(Keywords.IntType),
    new TokenId("parameter2"),
        new TokenOperator(Operators.ClosingCircleBracket)};

        private ParserService parserService = new ParserService();

        [Test]
        public void ZeroParameterParse()
        {
            parserService.Initialize(new LexicalAnalyzerMock(zeroParameters));
            var parameterListParser = new ParameterListParser(parserService);
            var parameterList = parameterListParser.Parse();
            Assert.AreEqual(0, parameterList.Count());
        }

        [Test]
        public void OneParameterParseCount()
        {
            parserService.Initialize(new LexicalAnalyzerMock(oneParameter));
            var parameterListParser = new ParameterListParser(parserService);
            var parameterList = parameterListParser.Parse();
            Assert.AreEqual(1, parameterList.Count());
        }

        [Test]
        public void OneParameterParse()
        {
            parserService.Initialize(new LexicalAnalyzerMock(oneParameter));
            var parameterListParser = new ParameterListParser(parserService);
            var parameterList = parameterListParser.Parse();
            Assert.AreEqual("parameter1", parameterList[0].Name);
        }

        [Test]
        public void TwoParameterParseCount()
        {
            parserService.Initialize(new LexicalAnalyzerMock(twoParameter));
            var parameterListParser = new ParameterListParser(parserService);
            var parameterList = parameterListParser.Parse();
            Assert.AreEqual(2, parameterList.Count());
        }
    }
}
