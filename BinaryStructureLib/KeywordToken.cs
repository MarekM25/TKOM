using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib
{
    public class KeywordToken : Token
    {
        public new string SomePropertyName
        {
            get
            { // since we know our local SomePropertyImpl actually returns a Child
                return (string)SomePropertyImpl();
            }
        }
        protected override object SomePropertyImpl()
        {
            // do something different, might return a Child
            // but typed as Father for the return
            return "test";
        }
        public void test()
        {
           
        }
    }
}
