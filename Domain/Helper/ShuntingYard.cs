namespace CSTechnicalChallenges.Domain.Helper
{
	internal static class ShuntingYard
	{
		#region Attributes

		private static readonly Dictionary<char, int> OperatorPrecedence = new Dictionary<char, int>()
		{
			{'+', 1},
			{'-', 1},
			{'*', 2},
			{'/', 2}
		};

		#endregion

		internal static List<string> ConvertToPostfix(string expression)
		{
			List<string> postfixTokens = new List<string>();
			Stack<char> operatorStack = new Stack<char>();

			string[] tokens = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string token in tokens)
			{
				if (int.TryParse(token, out int number))
				{
					postfixTokens.Add(number.ToString());
				}
				else if (OperatorPrecedence.ContainsKey(token[0]))
				{
					while (operatorStack.Count > 0 &&
						   OperatorPrecedence.ContainsKey(operatorStack.Peek()) &&
						   OperatorPrecedence[operatorStack.Peek()] >= OperatorPrecedence[token[0]])
					{
						postfixTokens.Add(operatorStack.Pop().ToString());
					}
					operatorStack.Push(token[0]);
				}
			}

			while (operatorStack.Count > 0)
			{
				postfixTokens.Add(operatorStack.Pop().ToString());
			}

			return postfixTokens;
		}

        internal static float CalculatePostfix(List<string> postfixTokens)
        {
            Stack<float> operandStack = new Stack<float>();

            foreach (string token in postfixTokens)
            {
                if (int.TryParse(token, out int number))
                {
                    operandStack.Push(number);
                }
                else if (OperatorPrecedence.ContainsKey(token[0]))
                {
                    float operand2 = operandStack.Pop();
                    float operand1 = operandStack.Pop();

                    if (token[0] == '/' && operand2 == 0)
                    {
                        throw new DivideByZeroException("Divisão por zero não é permitida.");
                    }

                    switch (token[0])
                    {
                        case '+':
                            operandStack.Push(operand1 + operand2);
                            break;
                        case '-':
                            operandStack.Push(operand1 - operand2);
                            break;
                        case '*':
                            operandStack.Push(operand1 * operand2);
                            break;
                        case '/':
                            operandStack.Push(operand1 / operand2);
                            break;
                    }
                }
            }

            return operandStack.Pop();
        }
    }
}
