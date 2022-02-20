using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TempConverter
    {
        public static (string, string) InputTempConverter()
        {
            Console.WriteLine($"Skriv C för att konvertera TILL Celcius från Fahrenheit \n" +
                $"Skriv F för att konvertera TILL Fahrenheit från Celcius");
            string input = Console.ReadLine();
            input = input.ToLower();

            Calculator.EasterEggDetector(input);

            while (input != "c" && input != "celcius" && input != "f" && input != " fahrenheit")
            {
                Console.WriteLine($"Du skrev '{input}' detta var ej ett alternativ, försök igen");
                input = Console.ReadLine();
                Calculator.EasterEggDetector(input);
            }

            Console.WriteLine("Var god mata in anatalet grader");
            string inputTemp = Console.ReadLine();

            return (input, inputTemp);
        }
        public static decimal ConvertToCelcius (string inputTemp)
        {
            decimal tempFahrenheit = 0;
            while(!decimal.TryParse(inputTemp, out tempFahrenheit))
            {
                Console.WriteLine($"Du matade in '{inputTemp}' som din temperatur, detta är ej ett heltal eller decimaltal.\n" +
                    $"Var god försök igen.");
                inputTemp = Console.ReadLine();
            }
            decimal celsiusResult = (tempFahrenheit - 32) / (9/5);

            return celsiusResult;
        }
        public static decimal ConvertToFahrenheit(string inputTemp)
        {
            decimal tempCelcius = 0;
            while (!decimal.TryParse(inputTemp, out tempCelcius))
            {
                Console.WriteLine($"Du matade in {inputTemp} som din temperatur, detta är ej ett heltal eller decimaltal.\n" +
                    $"Var god försök igen.");
                inputTemp = Console.ReadLine();
            }
            decimal fahrenheitResult = (tempCelcius * (9/5)) + 32;

            return fahrenheitResult;
        }

    }
    

}
