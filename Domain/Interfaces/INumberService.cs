namespace CSTechnicalChallenges.Domain.Interfaces
{
	public interface INumberService
	{
		/// <summary>
		/// Transforma um número inteiro para sua representação por extenso.
		/// </summary>
		/// <param name="numberToWord">Número inteiro,</param>
		/// <returns>Representação por extenso.</returns>
		string ToWords(long numberToWord);

		/// <summary>
		/// Realiza a soma de um conjunto de números inteiros.
		/// </summary>
		/// <param name="toSum">Conjunto de números inteiros.</param>
		/// <returns>Soma de todos os elementos do conjunto.</returns>
		long Sum(long[] toSum);

		/// <summary>
		/// Resolve expressão matemática fornecida.
		/// </summary>
		/// <param name="mathExpression">Expressão matemática.</param>
		/// <returns>Resultado da expressão matemática fornecida.</returns>
		long ProcessMathExpression(string mathExpression);
	}
}
