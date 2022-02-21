using System;
namespace ClassLibrary
{
	public class TempConverters
	{
        public static decimal ConvertToCelcius(string? inputTemp)
        {
            decimal tempFahrenheit = 0;
            while (!decimal.TryParse(inputTemp, out tempFahrenheit))
            {
                Console.WriteLine($"Du matade in '{inputTemp}' som din temperatur, detta är ej ett heltal eller decimaltal.\n" +
                    $"Var god försök igen.");
                inputTemp = Console.ReadLine();
            }
            decimal celsiusResult = (tempFahrenheit - 32) / (9 / 5);

            return celsiusResult;
        }
        public static decimal ConvertToFahrenheit(string? inputTemp)
        {
            decimal tempCelcius = 0;
            while (!decimal.TryParse(inputTemp, out tempCelcius))
            {
                Console.WriteLine($"Du matade in {inputTemp} som din temperatur, detta är ej ett heltal eller decimaltal.\n" +
                    $"Var god försök igen.");
                inputTemp = Console.ReadLine();
            }
            decimal fahrenheitResult = (tempCelcius * (9 / 5)) + 32;

            return fahrenheitResult;
        }
    }
}

