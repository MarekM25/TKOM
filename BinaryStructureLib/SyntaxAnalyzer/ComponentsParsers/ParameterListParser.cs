using BinaryStructureLib.Analyzer;
using BinaryStructureLib.Structures;
using BinaryStructureLib.Tokens;
using System.Collections.Generic;

namespace BinaryStructureLib.SyntaxAnalyzer.ComponentsParsers
{
    public class ParameterListParser
    {
        private ParserService parserService;

        public ParameterListParser(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public List<Parameter> Parse()
        {
            List<Parameter> listOfParameters = new List<Parameter>();
            parserService.Expect(new TokenOperator(Operators.OpeningCircleBracket));
            if (parserService.EqualsCurrentToken(new TokenOperator(Operators.ClosingCircleBracket)))
            {
                parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
                return listOfParameters;
            }
            do
            {
                var parameterParser = new ParameterParser(parserService);
                var parameter = parameterParser.Parse();
                listOfParameters.Add(parameter);
            }
            while (parserService.Accept(new TokenOperator(Operators.Comma)));
            parserService.Expect(new TokenOperator(Operators.ClosingCircleBracket));
            return listOfParameters;
        }
    }
}
