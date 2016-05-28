﻿using BinaryStructureLib.Structures.ConditionExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStructureLib.Analyzer;

namespace BinaryStructureLib.Structures.Statements
{
    public class IfStatement : Statement
    {
        public Expression condition { get; set; }
        public List<Statement> statements;
        public bool hasAlternatives { get; set; }
        public List<Statement> alternativeStatements;
        IInterpreterService interpreterService;

        private List<InterpreterResult> interpretStatementList(List<Statement> statements)
        {
            var results = new List<InterpreterResult>();
            foreach (var statement in statements)
            {
                results.AddRange(statement.Interpret(interpreterService));
            }
            return results;
        }


        public override List<InterpreterResult> Interpret(IInterpreterService interpreterService)
        {
            List<InterpreterResult> results;
            this.interpreterService = interpreterService;
            if (condition.Evaluate())
                results = interpretStatementList(statements);
            else
                results = interpretStatementList(alternativeStatements);
            return results;
        }
    }
}
