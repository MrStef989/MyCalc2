using System;
using System.Collections.Generic;

namespace MyCalc2
{
    public class Symbols
    {
        public List<string> Tokenize(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new InvalidOperationException("Выражение не может быть пустым.");
            }

            var tokens = new List<string>();
            var currentToken = string.Empty;
            char? previousChar = null;

            foreach (var ch in expression)
            {
                if (char.IsWhiteSpace(ch))
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }
                    previousChar = ch;
                    continue;
                }

                if (char.IsDigit(ch) || ch == '.')
                {
                    currentToken += ch;
                }
                else if (IsOperator(ch) || ch == '(' || ch == ')')
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }

                    // Обработка отрицательных чисел
                    if (ch == '-' && (previousChar == null || previousChar == '(' || IsOperator(previousChar.Value)))
                    {
                        currentToken += ch; // Начало отрицательного числа
                    }
                    else
                    {
                        tokens.Add(ch.ToString());
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный символ: {ch}");
                }

                previousChar = ch;
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private bool IsNegativeSign(char currentChar, char? previousChar)
        {
            return currentChar == '-' && (previousChar == null || previousChar == '(' || IsOperator(previousChar.Value));
        }

        private bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }
    }
}