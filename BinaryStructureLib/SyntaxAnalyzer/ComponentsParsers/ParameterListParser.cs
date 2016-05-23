using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System.Collections.Generic;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class ParameterListParser
    {
        public List<Parameter> Parse()
        {
            List<Parameter> listOfParameters = new List<Parameter>();
            ParserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            if (ParserService.EqualsCurrentToken(new TokenOperator(Operators.ClosingCircleBracket)))
            {
                ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
                return listOfParameters;
            }
            do
            {
                var parameterParser = new ParameterParser();
                var parameter = parameterParser.Parse();
                listOfParameters.Add(parameter);
            }
            while (ParserService.Accept(new TokenOperator(Operators.Comma)));
            ParserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return listOfParameters;
        }
    }
}
