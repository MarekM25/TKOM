using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers;
using BinaryStructureLib.SyntaxAnalyzer;
using BinaryStructureLib;
using BinaryStructureLib.Tokens;

namespace BinaryStructureTestsNunit.Parser
{
    [TestFixture]
    public class StructParserTests
    {
        private TokenBase[] tokens = new TokenBase[]
            {  new TokenKeyword(Keywords.StructType) };
        [Test]
        public void Test()
        {
            ParserService.Initialize(new LexicalAnalyzerMock(tokens));
            StructParser.Parse();
        } 
    }
}
