using System;
namespace ClassLibrary
{
	public class StringConverter
	{
        public static List<string> StringToList(string input)
        {
            char[] splitOn = { '+', '-', '*', '/', '^', '(', ')' };


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsNumber(input[i]))
                {
                    Console.WriteLine(input[i]);
                }
            }
            Console.WriteLine("------");
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


            if (input[0] == ' ')
            {
                input = input.Remove(0, 1);
            }


            if (input[input.Length - 1] == ' ')
                input = input.Remove(input.Length - 1, 1);


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ' && input[i + 1] == ' ')
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }
            int nextItem = 0;
            for (int i = 0; i < input.Length - 2; i++)
            {
                nextItem = i + 2;
                foreach (var item in splitOn)
                {
                    if (input[i] == item && input[nextItem] == '-')
                    {
                        input = input.Remove(i + 3, 1);
                    }
                }
            }
            //Prints the string: REMOVE BEFORE TURNING IN ASSIGNMENT!!
            Console.WriteLine(input);
            Console.ReadKey();
            //Splits the string into a List<string> to facilitate postfix conversion.
            List<string> infixList = new(input.Split(" "));

            //Prints the list: REMOVE BEFORE TURNING IN ASSIGNMENT!!
            foreach (var item in infixList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");
            Console.ReadKey();
            return infixList;
        }
    }
}

