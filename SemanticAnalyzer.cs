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

            Definition floatDefinition = new FloatDefinition();
            floatDefinition.name = "float";

            Definition constDefinition = new ConstDefinition();
            constDefinition.name = "const";

            // Create a definition for Strings
            Definition strDefinition = new StringDefinition();
            strDefinition.name = "str";

            // Register definitions with the Global Symbol Table
            globalSymbolTable.Add("int", intDefinition);
            globalSymbolTable.Add("str", strDefinition);
        }

        public void PrintWarning(Token t, String message)
        {
            Console.WriteLine("Line " + t.Line + ", Col " + t.Pos + ": " + message);
        }

        //---------------------------------------------
        // Operands
        //---------------------------------------------
        public override void OutAIntegerOperand(AIntegerOperand node)
        {
            //Create the definition
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            decoratedParseTree.Add(node, intDefinition);
        }
        public override void OutAFloatOperand(AFloatOperand node)
        {
            //Create the definition
            Definition floatDefinition = new FloatDefinition();
            floatDefinition.name = "float";

            decoratedParseTree.Add(node, floatDefinition);
        }
        public override void OutAStringOperand(AStringOperand node)
        {
            //Create the definition
            Definition strDefinition = new StringDefinition();
            strDefinition.name = "str";

            decoratedParseTree.Add(node, strDefinition);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            //Get the name of the ID
            String varName = node.GetId().Text;

            Definition varDefinition;

            if (!localSymbolTable.TryGetValue(varName, out varDefinition))
            {
                PrintWarning(node.GetId(), varName + " does not exist!");
            }
            else if (!(varDefinition is VariableDefinition))
            {
                PrintWarning(node.GetId(), varName + " is not a variable!");
            }
            else
            {
                VariableDefinition v = (VariableDefinition)varDefinition;

                decoratedParseTree.Add(node, v.variableType);
            }
        }

        //---------------------------------------------
        // Expression 4
        //---------------------------------------------
        public override void OutAPassExpression4(APassExpression4 node)
        {
            Definition operandDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetOperand(), out operandDefinition))
            {
                // The error would have been printed at a lower level in the tree
                // We don't have to print anything here! 
            }
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }

        public override void OutANegativeExpression4(ANegativeExpression4 node)
        {
            Definition operandDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetOperand(), out operandDefinition))
            {
                // The error would have been printed at a lower level in the tree
                // We don't have to print anything here! 
            }
            else if (!(operandDefinition is NumberDefinition))
            {
                PrintWarning(node.GetMinus(), "Only a number can be negated!");
            }
            /*else if (!(operandDefinition is FloatDefinition))
            {
                PrintWarning(node.GetMinus(), "Only a number can be negated!");
            }*/
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }

        //---------------------------------------------
        // Expression 3
        //---------------------------------------------
        public override void OutAPassExpression3(APassExpression3 node)
        {
            Definition expression4Definition;

            if (!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Definition))
            {
                // The error would have been printed at a lower level in the tree
                // We don't have to print anything here! 
            }
            else
            {
                decoratedParseTree.Add(node, expression4Definition);
            }
        }

        public override void OutAParenthesisExpression3(AParenthesisExpression3 node)
        {
            Definition expressionDef;
            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                //Maybe error is already printed?
            }
            else if (expressionDef.name == "str" || expressionDef.name == "const")
            {
                Console.WriteLine("Cannot put string or constant into parentheses");
            }
        }

        //---------------------------------------------
        // Expression 2
        //---------------------------------------------
        public override void OutAPassExpression2(APassExpression2 node)
        {
            Definition expression3Definition;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Definition))
            {
                // The error would have been printed at a lower level in the tree
                // We don't have to print anything here! 
            }
            else
            {
                decoratedParseTree.Add(node, expression3Definition);
            }
        }

        public override void OutAMultiplyExpression2(AMultiplyExpression2 node)
        {
            Definition expression2;
            Definition expression3;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2))
            {
                //Error caught earlier
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3))
            {
                //Error caught earlier
            }
            else if (expression2.GetType() != expression3.GetType())
            {
                PrintWarning(node.GetMult(), "Cannot multiply " + expression2.name + " by " + expression3.name);
            }
            else if (expression2 is StringDefinition)
            {
                PrintWarning(node.GetMult(), "You can only multiply ints or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expression2);
            }

        }

        public override void OutADivideExpression2(ADivideExpression2 node)
        {
            Definition expression2;
            Definition expression3;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2))
            {
                //Error caught earlier
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3))
            {
                //Error caught earlier
            }
            else if (expression2.GetType() != expression3.GetType())
            {
                PrintWarning(node.GetDiv(), "Cannot divide " + expression2.name + " by " + expression3.name);
            }
            else if (expression2 is StringDefinition)
            {
                PrintWarning(node.GetDiv(), "You can only divide ints or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expression2);
            }
        }

        //---------------------------------------------
        // Expression 1
        //---------------------------------------------
        public override void OutAPassExpression(APassExpression node)
        {
            Definition expression2Definition;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Definition))
            {
                // The error would have been printed at a lower level in the tree
                // We don't have to print anything here! 
            }
            else
            {
                decoratedParseTree.Add(node, expression2Definition);
            }
        }

        public override void OutAAddExpression(AAddExpression node)
        {
            Definition expression;
            Definition expression2;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {
                //Error caught earlier
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2))
            {
                //Error caught earlier
            }
            else if (expression.GetType() != expression2.GetType())
            {
                PrintWarning(node.GetPlus(), "Cannot add " + expression.name + " with " + expression2.name);
            }
            else if (expression is StringDefinition)
            {
                PrintWarning(node.GetPlus(), "You can only add ints or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expression);
            }
        }

        public override void OutASubtractExpression(ASubtractExpression node)
        {
            Definition expression;
            Definition expression2;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {
                //Error caught earlier
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2))
            {
                //Error caught earlier
            }
            else if (expression.GetType() != expression2.GetType())
            {
                PrintWarning(node.GetMinus(), "Cannot subtract " + expression.name + " with " + expression2.name);
            }
            else if (expression is StringDefinition)
            {
                PrintWarning(node.GetMinus(), "You can only subtract ints or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expression);
            }
        }

        //---------------------------------------------
        // Declare Statement
        //---------------------------------------------
        public override void OutADeclaration(ADeclaration node)
        {
            Definition typeDef;
            Definition idDef;
            String type;
            PType p = node.GetType();
            if (p is AIntType)
            {
                AIntType a = (AIntType)p;
                type = a.GetIntdec().Text;
            }
            else if (p is AStrType)
            {
                AStrType a = (AStrType)p;
                type = a.GetStrdec().Text;
            }
            else if (p is AFloatType)
            {
                AFloatType a = (AFloatType)p;
                type = a.GetFloatdec().Text;
            }
            else if (p is AConstType)
            {
                AConstType a = (AConstType)p;
                type = a.GetConstdec().Text;
            }
            else
            {
                type = "";
            }

            if (!globalSymbolTable.TryGetValue(type, out typeDef))
            {
                Console.WriteLine("Type " + type + " does not exist!");
            }
            else if (!(typeDef is TypeDefinition))
            {
                Console.WriteLine("Identifier " + type + " is not a recognized data type");
            }
            else if (localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else if (globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else
            {
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetId().Text;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                localSymbolTable.Add(node.GetId().Text, newVariableDefinition);

            }

        }

        //---------------------------------------------
        // Assignment
        //---------------------------------------------
        public override void OutAAssignment(AAssignment node)
        {
            Definition idDef;
            Definition expressionDef;

            if (!localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " does not exist");
            }
            else if (!(idDef is VariableDefinition))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is not a variable");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // Should be caught earlier
            }
            else if (((VariableDefinition)idDef).variableType.name != expressionDef.name)
            {
                PrintWarning(node.GetId(), "Types don't match");
            }
            else
            {
                //Do nothing
            }
        }

        //---------------------------------------------
        // Subfunction Definition
        //---------------------------------------------
        
    }
}
