using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TempInputs
    {
        public static (string, string) InputTempConverter()
        {
            Console.WriteLine($"Skriv C för att konvertera TILL Celcius från Fahrenheit \n" +
                $"Skriv F för att konvertera TILL Fahrenheit från Celcius");
            string? input = Console.ReadLine();
            input = input.ToLower();

            CalculatorInput.EasterEggDetector(input);

            while (input != "c" && input != "celcius" && input != "f" && input != " fahrenheit")
            {
                Console.WriteLine($"Du skrev '{input}' detta var ej ett alternativ, försök igen");
                input = Console.ReadLine();
                CalculatorInput.EasterEggDetector(input);
            }

            Console.WriteLine("Var god mata in anatalet grader");
            string? inputTemp = Console.ReadLine();

            return (input, inputTemp);
        }
        

    }
    

}
