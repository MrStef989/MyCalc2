using System;
using System.Collections.Generic;

namespace MyCalc2
{
    public class TokenValidator
    {
        public void ValidateTokens(List<string> tokens)
        {
            int parenthesesBalance = 0;
            bool expectOperand = true;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (token == "(")
                {
                    parenthesesBalance++;
                    expectOperand = true;
                    continue;
                }

                if (token == ")")
                {
                    parenthesesBalance--;
                    if (parenthesesBalance < 0)
                    {
                        throw new InvalidOperationException("Несбалансированные скобки.");
                    }
                    expectOperand = false;
                    continue;
                }

                if (IsOperator(token))
                {
                    if (expectOperand)
                    {
                        if (token == "-" && (i == 0 || tokens[i - 1] == "(" || IsOperator(tokens[i - 1])))
                        {
                            // Отрицательное число, следующий токен должен быть числом
                            expectOperand = true;
                        }
                        else
                        {
                            throw new InvalidOperationException("Оператор встречен без числа перед ним.");
                        }
                    }
                    else
                    {
                        expectOperand = true;
                    }
                }
                else if (IsNumber(token))
                {
                    if (!expectOperand)
                    {
                        throw new InvalidOperationException("Два числа подряд без оператора.");
                    }
                    expectOperand = false;
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный токен: {token}");
                }
            }

            if (parenthesesBalance != 0)
            {
                throw new InvalidOperationException("Несбалансированные скобки.");
            }

            if (expectOperand)
            {
                throw new InvalidOperationException("Выражение заканчивается оператором.");
            }
        }

        private bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        private bool IsNumber(string token)
        {
            return double.TryParse(token, out _);
        }
    }
}
