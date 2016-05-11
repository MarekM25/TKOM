using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BinaryStructureLib;
using System.Reflection;
using System.Collections.Generic;

namespace TestsBinaryStructure
{

    [TestClass]
    public class StreamTests
    {
        private static string dirTestFiles = @"TestFiles";
        private static string charWithoutWithespace = Path.Combine(dirTestFiles, "CharWithoutFirstWithespace.txt");
        private static string charWithWithespace = Path.Combine(dirTestFiles, "CharWithFirstWhitespace.txt");
        private static string languageExample1 = Path.Combine(dirTestFiles, "LanguageExample.txt");
        [TestMethod]
        public void FirstNotWhiteSpaceCharTests()
        {
            //arrange
            Stream stream = System.IO.File.OpenRead(charWithoutWithespace); ;
            //act
            char actual;
            stream.FirstNotWhiteSpaceChar(out actual);
            char expected = 'f';

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FirstWhiteSpaceCharTests()
        {
            //arrange
            Stream stream = System.IO.File.OpenRead(charWithWithespace); ;
            //act
            char actual;
            stream.FirstNotWhiteSpaceChar(out actual);
            //assert
            Assert.AreEqual('f', actual);
        }


        [TestMethod]
        public void GetNextWordTests()
        {
            //arrange
            Stream stream = System.IO.File.OpenRead(charWithoutWithespace);
            //act
            string actual;
            stream.NextWord(out actual);
            string expected = "fdsafdsa";

            //assert
            Assert.AreEqual(expected, actual, "Actual1 " + actual);


            string actual2;
            stream.NextWord(out actual2);
            string expected2 = "dsaf";

            //assert
            Assert.AreEqual(expected2, actual2, "Actual2: " + actual2);

            stream.Close();


            stream = System.IO.File.OpenRead(charWithWithespace);

            string actual3;
            stream.NextWord(out actual3);
            string expected3 = "fdsafdsa";

            //assert
            Assert.AreEqual(expected3, actual3, "Actual3: " + actual3);

            string actual4;
            stream.NextWord(out actual4);
            string expected4 = "tests";

            //assert
            Assert.AreEqual(expected4, actual4, "Actual4: " + actual4);
        }

        [TestMethod]
        public void allWordsLanguageExampleTests()
        {
            Stream stream = System.IO.File.OpenRead(languageExample1);
            List<string> expectedWordList = new List<string>()
            {
                "struct",
                "T",
                "(",
                "int",
                "parameter1",
                ",",
                "int",
                "parameter2",
                ",",
                "bool",
                "boolParameter",
                ")",
                "begin"
            };
            List<string> actualWordLists = new List<string>();

            string nextWord = string.Empty;
            while (true)
            {
                if (!stream.NextWord(out nextWord))
                {
                    break;
                }
                else
                    actualWordLists.Add(nextWord);
            }
            CollectionAssert.AreEqual(expectedWordList, actualWordLists);
        }
    }
}
