using System;
using ClassLibrary;


namespace program;

public class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Du kan antingen använda miniräknaren eller temperatur omvandlaren.\n" +
            "Skriv 'M' eller 'miniräknare' alt 'T' eller 'temp' för att använda respektive funktion");
        string choice = Console.ReadLine();
        choice = choice.ToLower();

        CalculatorInput.EasterEggDetector(choice);
        while(choice != "m" && choice != "miniräknare" && choice != "t" && choice != "temp")
        {
            Console.WriteLine($"Du skrev {choice} detta var ej ett alternativ. Försök igen.");
            choice = Console.ReadLine();
            CalculatorInput.EasterEggDetector(choice);
        }

        Console.Clear();


        if (choice == "m" || choice == "miniräknare")
        {
        string inputCalc = CalculatorInput.Input();
        List<string> infixList = StringConverter.StringToList(inputCalc);
        List<string> outfixList = InfixToPostfix.PostfixConverter(infixList);
        decimal result = Calculations.Calculator(outfixList);
        Console.WriteLine(result);
        }

        else if (choice == "t" || choice == "temp")
        {

        (string input, string inputTemp) = TempInputs.InputTempConverter();
        decimal tempResult = 0;
        if (input == "c" || input == "celcius")
        {
            tempResult = TempConverters.ConvertToCelcius(inputTemp);
        }
        else if (input == "f" || input == "fahrenheit")
        {
            tempResult = TempConverters.ConvertToFahrenheit(inputTemp);
        }

        string tempScale = "";
        string fromTempScale = "";
        if (input == "c" || input == "celcius")
        {
            tempScale = "Celcius";
            fromTempScale = "Fahrenheit";
        }
        else if (input == "f" || input == "fahrenheit")
        {
            tempScale = "Fahrenheit";
            fromTempScale = "Celcius";
        }
        Console.WriteLine($"{inputTemp} {fromTempScale} = {tempResult} {tempScale}");
        }

        Console.ReadKey();
    }
    
}

