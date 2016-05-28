using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class ParameterParser
    {
        public Parameter Parse()
        {
            Parameter parameter = new Parameter();
            if (ParserService.Accept(new TokenKeyword(Keywords.IntType)))
                parameter.Type = Keywords.IntType;
            else if (ParserService.Accept(new TokenKeyword(Keywords.BoolType)))
                parameter.Type = Keywords.BoolType;
            else
            {
                //error
                return null;
            }
            ParserService.Expect(new TokenId());
            parameter.Name = (string)ParserService.PreviousTokenValue();
            return parameter;
        }
    }
}