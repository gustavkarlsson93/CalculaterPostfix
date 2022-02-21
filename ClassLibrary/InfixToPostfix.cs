using System;
namespace ClassLibrary
{
	public class InfixToPostfix
	{
        private static int PriorityOfOperators(string item)
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
        public static List<string> PostfixConverter(List<string> infixList)
        {
            Stack<string> stack1 = new Stack<string>();
            List<string> postfix = new List<string>();
            foreach (var item in infixList)
            {
                if (item == "(")
                {
                    stack1.Push(item);
                }
                //Pops all strings to postfix until ")" is found
                else if (item == ")")
                {
                    while (stack1.Peek() != "(")
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
                        stack1.Push(item);
                    }
                    else
                    {   //Check the if the operator in top of stack has priority over the item.
                        //if stack operator has higher order pop operator from stack and push item.
                        if (PriorityOfOperators(stack1.Peek()) <= PriorityOfOperators(item))
                        {
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
            if (stack1.Count != 0)
            {
                while (stack1.Count != 0)
                {
                    string temp = stack1.Pop();
                    postfix.Add(temp);
                }
            }
            foreach (var item in postfix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");
            Console.ReadKey();

            return postfix;
        }
    }
}

