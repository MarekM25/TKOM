using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Structures.Statements
{
    public class OwnTypeDeclaration : Statement
    {
        public string TypeName { get; set; }
        public List<object> Values = new List<object>();
    }
}
