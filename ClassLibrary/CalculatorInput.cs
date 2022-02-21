using System;
namespace ClassLibrary
{
	public class CalculatorInput
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
    }
}

