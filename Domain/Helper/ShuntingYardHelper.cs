namespace CSTechnicalChallenges.Domain.Helper
{
	/// <summary>
	/// Classe auxiliar para tratamento de notação infixa para pósfixadas (notação polonesa inversa (RPN)).
	/// </summary>
	internal static class ShuntingYardHelper
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

		#region Methods

		/// <summary>
		/// Converte uma expressão de notação infixa para RPN conforme o algorítmo de Dijkstra.
		/// </summary>
		/// <param name="expression">Expressão matemática.</param>
		/// <returns>Notação RPN.</returns>
		/// <exception cref="FormatException">Lança uma exceção caso o formato da expressão esteja errado.</exception>
		internal static List<string> ConvertToPostfix(string expression)
		{
			if (expression.Split(' ').Length == 1)
			{
				throw new FormatException("O formato da expressão é inválido.");
			}

			List<string> postfixTokens = new();
			Stack<char> operatorStack = new();

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
				else
				{
					throw new FormatException("O formato da expressão é inválido.");
				}
			}

			while (operatorStack.Count > 0)
			{
				postfixTokens.Add(operatorStack.Pop().ToString());
			}

			return postfixTokens;
		}

		/// <summary>
		/// Realiza o cálculo de uma expressão matemática em notação polonesa inversa.
		/// </summary>
		/// <param name="postfixTokens">Expressão em notação polonesa inversa.</param>
		/// <returns>Resolução da expressão matemática.</returns>
		/// <exception cref="FormatException">Lança uma exceção em caso de divisão por zero.</exception>
		/// <exception cref="DivideByZeroException">Lança uma exceção caso o formato da expressão esteja errado.</exception>
		internal static long CalculatePostfix(List<string> postfixTokens)
		{
			Stack<long> operandStack = new();

			foreach (string token in postfixTokens)
			{
				if (int.TryParse(token, out int number))
				{
					operandStack.Push(number);
				}
				else if (OperatorPrecedence.ContainsKey(token[0]))
				{
					if (operandStack.Count < 2)
					{
						throw new FormatException("O formato da expressão é inválido.");
					}
					
					long operand2 = operandStack.Pop();
					long operand1 = operandStack.Pop();

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

		#endregion
	}
}
