using BinaryStructureLib.Exceptions;
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
        private ParserService parserService;

        public ParameterParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public Parameter Parse()
        {
            Parameter parameter = new Parameter();
            if (parserService.Accept(new TokenKeyword(Keywords.IntType)))
                parameter.Type = Keywords.IntType;
            else if (parserService.Accept(new TokenKeyword(Keywords.BoolType)))
                parameter.Type = Keywords.BoolType;
            else
                throw new SyntaxAnalyzerException(parserService.CurrentToken(),"Nieoczekiwany typ.");
            parserService.Expect(new TokenId());
            var variableName = (string)parserService.PreviousTokenValue();
            parserService.AddNewVariableName(variableName);
            parameter.Name = variableName;
            return parameter;
        }
    }
}