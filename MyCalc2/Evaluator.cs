using System;
using System.Collections.Generic;

namespace MyCalc2
{
    public class Evaluator
    {
        public double Evaluate(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double number))
                {
                    HandleNumber(stack, number);
                }
                else
                {
                    HandleOperator(stack, token);
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Некорректное выражение.");
            }

            return stack.Pop();
        }

        private void HandleNumber(Stack<double> stack, double number)
        {
            stack.Push(number);
        }

        private void HandleOperator(Stack<double> stack, string operation)
        {
            if (stack.Count < 2)
            {
                throw new InvalidOperationException("Недостаточно чисел для выполнения операции.");
            }

            var b = stack.Pop();
            var a = stack.Pop();

            var result = PerformOperation(a, b, operation);
            stack.Push(result);
        }

        private double PerformOperation(double a, double b, string operation)
        {
            return operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? a / b : throw new DivideByZeroException("Деление на ноль."),
                _ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
            };
        }
    }
}