using BinaryStructureLib.LexicalAnalayzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.LexicalAnalyzer
{
    [TestFixture]
    public class NextStringTokenReaderTests
    {
        private static string dirTestFiles = @"C:\Users\Marek\Projekty\TKOM\BinaryStructure\BinaryStructureTestsNunit\bin\Debug\TestFiles";
        private static string charWithoutWithespace = Path.Combine(dirTestFiles, "SimpleLanguageExample.txt");
        private static string simpleTest2 = Path.Combine(dirTestFiles, "SimpleTest2.txt");
        NextTokenStringReader nextTokenStringReader;

        public NextStringTokenReaderTests()
        { 
           var streamReader = new StreamReader(charWithoutWithespace);
            nextTokenStringReader = new NextTokenStringReader(streamReader);
        }

        [Test]
        public void test()
        {
            //while (true)
            //{
            //    var word = nextTokenStringReader.ReadNextTokenStringWord();
            //}
        }
    }
}
