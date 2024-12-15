using System;
using System.Collections.Generic;

namespace MyCalc2
{
    public class Converter
    {
        private readonly Dictionary<string, int> _precedence = new()
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 }
        };

        public List<string> ConvertToPostfix(List<string> tokens)
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            foreach (var token in tokens)
            {
                if (IsNumber(token))
                {
                    HandleNumber(token, output);
                }
                else if (token == "(")
                {
                    HandleOpenParenthesis(operators);
                }
                else if (token == ")")
                {
                    HandleCloseParenthesis(operators, output);
                }
                else if (IsOperator(token))
                {
                    HandleOperator(token, operators, output);
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный токен: {token}");
                }
            }

            while (operators.Count > 0)
            {
                var op = operators.Pop();
                if (op == "(")
                {
                    throw new InvalidOperationException("Несбалансированные скобки.");
                }
                output.Add(op);
            }

            return output;
        }

        private bool IsNumber(string token) => double.TryParse(token, out _);

        private bool IsOperator(string token) => _precedence.ContainsKey(token);

        private void HandleNumber(string token, List<string> output)
        {
            output.Add(token);
        }

        private void HandleOpenParenthesis(Stack<string> operators)
        {
            operators.Push("(");
        }

        private void HandleCloseParenthesis(Stack<string> operators, List<string> output)
        {
            while (operators.Count > 0 && operators.Peek() != "(")
            {
                output.Add(operators.Pop());
            }

            if (operators.Count == 0 || operators.Pop() != "(")
            {
                throw new InvalidOperationException("Несбалансированные скобки.");
            }
        }

        private void HandleOperator(string token, Stack<string> operators, List<string> output)
        {
            while (operators.Count > 0 && IsOperator(operators.Peek()) &&
                   _precedence[operators.Peek()] >= _precedence[token])
            {
                output.Add(operators.Pop());
            }
            operators.Push(token);
        }
    }
}