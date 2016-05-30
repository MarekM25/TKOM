using BinaryStructureLib.Structures;
using BinaryStructureLib.Structures.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureTestsNunit.Interpreter
{
    [TestFixture]
    public class InitStructureTests
    {
        private BinaryStructure binaryStructure = new BinaryStructure();
        private OwnTypeDeclaration ownTypeDeclaration = new OwnTypeDeclaration() { Name = "Test", Values = new List<object>() { 4,47 } };
        public InitStructureTests()
        {
            Structure structure = new Structure();
            structure.Name = "Test";
            structure.Parameters.Add(new Parameter() { Name = "parameter1" });
            structure.Parameters.Add(new Parameter() { Name = "parameter2" });
            binaryStructure.stuctDeclarations.Add(structure);
        }
        [Test]
        public void InitStructureSimpleTest()
        {
            binaryStructure.InitStructure(ownTypeDeclaration);
        }
    }
}
