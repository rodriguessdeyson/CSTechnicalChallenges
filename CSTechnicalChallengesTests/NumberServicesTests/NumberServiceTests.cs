using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Services;
using Xunit;

namespace CSTechnicalChallengesTests.NumberServicesTests
{
	public class NumberServiceTests
	{
		[Theory]
		[InlineData(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 45)]
        [MemberData(nameof(BuildOneMillionArray), 499999500000)]
        [InlineData(new long[] { }, 0)]
        private void SumOfIntegerArray(long[] integerToSum, long expected)
		{
			INumberService number = new NumberService();
			Assert.Equal(expected, number.Sum(integerToSum));
		}

		[Theory]
		[InlineData("4 + 5 + 6 + 7 + 8", 30)]
        [InlineData("15 * 5 + 5 / 2", 77.5)]
        private void EvaluateMathExpressions(string mathExpression, long expected)
		{
			INumberService number = new NumberService();
			Assert.Equal(expected, number.ProcessMathExpression(mathExpression));
		}

		[Theory]
		[InlineData("5 + 5 / 0")]
		private void EvaluateDivisonByZero(string mathExpression)
		{
			INumberService number = new NumberService();
			Assert.Throws<DivideByZeroException>(() => number.ProcessMathExpression(mathExpression));
		}

		[Theory]
		[InlineData("5+5/2")]
        [InlineData("552")]
        [InlineData("5 + / 2")]
        private void EvaluateWrongExpressionFormat(string mathExpression)
		{
			INumberService number = new NumberService();
			Assert.Throws<FormatException>(() => number.ProcessMathExpression(mathExpression));
		}

		[Theory]
        [InlineData(12450, "doze mil quatrocentos e cinquenta")]
		[InlineData(123, "cento e vinte e três")]
		[InlineData(658, "seiscentos e cinquenta e oito")]
        [InlineData(999, "novecentos e noventa e nove")]
        [InlineData(1000000, "um milhão")]
        [InlineData(3150000, "três milhões cento e cinquenta mil")]
        [InlineData(9999999, "nove milhões novecentos e noventa e nove mil novecentos e noventa e nove")]
        private void WriteTheNumberToWord(long numberToWord, string expected)
		{
			INumberService number = new NumberService();
			Assert.Equal(expected, number.ToWords(numberToWord));
		}

		#region Extension

		/// <summary>
		/// Gera um milhão de números inteiros.
		/// </summary>
		/// <returns>Enumeração com 1 milhão de inteiros.</returns>
		public static IEnumerable<object[]> BuildOneMillionArray()
		{
			yield return new object[]
			{
				Enumerable
					.Range(0, 1000000)
					.Select(el => (long)el)
					.ToArray()
			};
		}

		#endregion
	}
}

