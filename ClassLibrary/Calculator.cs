using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Calculator
    {
        public static string Input()
        {
            Console.WriteLine("Var god mata in din ekvation");
            string input = Console.ReadLine();
            EasterEggDetector(input);
            return input;

        }
        public static void EasterEggDetector(string input)
        {
            input = input.ToLower();
            if (input == "xyzzy")
            {
                Console.WriteLine("Nothing happens");
            }
        }
        public static List<string> StringConverter (string input)
        {   //Array of operators.
            char[] splitOn = { '+', '-', '*', '/', '^', '(', ')'};

            //removes all whitespaces for the input.
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }
            //inserts whitespace before and after an operator so we can split the string on them.
            for (int i = 0; i < input.Length; i++)
            {
                foreach (var item in splitOn)
                {
                    if (input[i] == item)
                    {
                        input = input.Insert(i, " ");
                        input = input.Insert(i + 2, " ");
                        i++;
                    }
                }
            }

            //if string starts with operator whitespace must be removed.
            if (input[0] == ' ')
                {
                    input = input.Remove(0, 1);
                }
            //If last item is operator removes the whitespace.
            //If we don't we will get argumentexception out of range in when we remove double whitespace.
             if (input[input.Length-1] == ' ')
                input = input.Remove(input.Length-1, 1);
            //removes 1 whitespace if there is two in a row. (Happens when you have 2 
            //operators in a row). If we have 2 whitespace in a argumentexeption out of range will happen in calc.
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ' && input[i + 1] == ' ')
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }
            
            //Splits the string into a List<string> to facilitate postfix conversion.
            List<string> infixList = new(input.Split(" "));
            
            foreach (var item in infixList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");
            Console.ReadKey();
            return infixList;
        }
        public static int PriorityOfOperators(string item)
        {
            if (item == "+" || item == "-")
                return 1;
            else if (item == "*" || item == "/")
                return 2;
            else if (item == "^")
                return 3;
            else
            return 0;
        }
        public static List<string> PostfixConverter (List<string> infixList)
        {
            Stack <string> stack1 = new Stack<string>();
            List <string> postfix = new List<string> ();
            foreach (var item in infixList)
            {
                if(item == "(")
                {
                    stack1.Push(item);
                }
                //Pops all strings to postfix until ")" is found
                else if (item == ")")
                {
                    while(stack1.Peek() != "(")
                    {
                        string temp = stack1.Pop();
                        postfix.Add(temp);
                    }
                    stack1.Pop();
                }
                else if (item == "+" || item == "-" || item == "*" || item == "/" || item == "^")
                {
                    if (stack1.Count == 0)
                    {
                        stack1.Push (item);
                    }
                    else
                    {   //Check the if the operator in top of stack has priority over the item.
                        //if stack operator has higher order pop operator from stack and push item.
                        if(PriorityOfOperators(stack1.Peek()) <= PriorityOfOperators(item)){
                            string temp = stack1.Pop();
                            postfix.Add(temp);
                            stack1.Push(item);
                        }
                        else
                        {
                            stack1.Push(item);
                        }
                    }
                }
                else
                {
                    // If item is operand add to Stack.
                    stack1.Push(item);
                }
                //poping out all remaining operators and adding to List.
            }
                if(stack1.Count != 0)
                {
                    while(stack1.Count != 0)
                    {
                        string temp = stack1.Pop();
                        postfix.Add(temp);
                    }
                }
            foreach (var item in infixList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");
            Console.ReadKey();
            foreach (var item in postfix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");
            Console.ReadKey();

            return postfix;
        }
        public static decimal Calculations (List<string> postfix)
        {
            Stack<decimal> values = new Stack<decimal>();

            foreach(string item in postfix)
            {
                decimal value;
                if(decimal.TryParse(item, out value))
                {
                    values.Push(value);
                }
                
                else
                {
                    decimal rhs = values.Pop();
                    decimal lhs = values.Pop();
                switch(item)
                {
                        case "+":
                        values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "^":
                            decimal temp =lhs;

                            for (int i = 1; i < rhs; i++)
                            {
                                temp *= lhs;
                            }
                            values.Push(temp);
                            break;
                         default:
                            throw new ArgumentException($"{item} is not a valid operator or operand.");
                }
                }
            }
            decimal result = values.Pop();
            return result;
        }
    }
}
