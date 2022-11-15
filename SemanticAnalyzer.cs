using CS426.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS426.analysis
{
    internal class SemanticAnalyzer : DepthFirstAdapter
    {
        // Global Symbol Table
        Dictionary<string, Definition> globalSymbolTable = new Dictionary<string, Definition>();

        // Local Symbol Table
        Dictionary<string, Definition> localSymbolTable = new Dictionary<string, Definition>();

        // Decorating the parse tree
        Dictionary<Node, Definition> decoratedParseTree = new Dictionary<Node, Definition>();


        public override void InAProgram(AProgram node)
        {
            // Create a definition for Integers
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            // Create a definition for Strings
            Definition strDefinition = new StringDefinition();
            strDefinition.name = "string";

            // Register definitions with the Global Symbol Table
            globalSymbolTable.Add("int", intDefinition);
            globalSymbolTable.Add("string", strDefinition);
        }
    }
}
