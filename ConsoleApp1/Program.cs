using System;
using MyCalc2;
namespace MyCalc2.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine("Добро пожаловать в консольный калькулятор!");
            Console.WriteLine("Введите 'exit' для выхода.");
            while (true)
            {
                Console.Write("Введите выражение: ");
                var input = Console.ReadLine();
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                    break;
                try
                {
                    var result = calculator.Calculate(input);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine();
            }

        }
    }
}