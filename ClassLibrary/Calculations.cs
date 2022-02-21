using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Calculations
    {


        public static decimal Calculator(List<string> postfix)
        {
            Stack<decimal> values = new Stack<decimal>();

            foreach (string item in postfix)
            {
                decimal value;
                if (decimal.TryParse(item, out value))
                {
                    values.Push(value);
                }

                else
                {
                    decimal rhs = values.Pop();
                    decimal lhs = values.Pop();
                    switch (item)
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
                            try
                            {
                            values.Push(lhs / rhs);
                            }
                            catch (DivideByZeroException e)
                            {
                                Console.WriteLine($"Exeption caught, {e}");
                            }
                            break;
                        case "^":
                            decimal temp = lhs;

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
