using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyCalc2
{
    public class Calculator
    {
        public double Calculate(string expression)
        {
            var elements = expression.Split(' ');


            var num1 = double.Parse(elements[0]);
            var num2 = double.Parse(elements[2]);
            var operation = elements[1];

            return operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Деление на ноль."),
                _ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
            };
        }

        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }
    }
}
