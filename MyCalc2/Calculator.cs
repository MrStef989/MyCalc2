using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCalc2
{
    public class Calculator
    {
        private readonly Symbols _symbols;
        private readonly Converter _postfixConverter;
        private readonly Evaluator _postfixEvaluator;
        private readonly TokenValidator _tokenValidator;

        public Calculator()
        {
            _symbols = new Symbols();
            _postfixConverter = new Converter();
            _postfixEvaluator = new Evaluator();
            _tokenValidator = new TokenValidator(); // Инициализация TokenValidator
        }

        public double Calculate(string expression)
        {
            var tokens = _symbols.Tokenize(expression);
            _tokenValidator.ValidateTokens(tokens); // Использование TokenValidator

            if (tokens.Count == 3)
            {
                var num1 = double.Parse(tokens[0]);
                var num2 = double.Parse(tokens[2]);
                var operation = tokens[1];

                return operation switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Деление на ноль."),
                    _ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
                };
            }

            var postfix = _postfixConverter.ConvertToPostfix(tokens);
            return _postfixEvaluator.Evaluate(postfix);
        }

        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }
    }
}
