using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Services;
using Xunit;

namespace CSTechnicalChallengesTests.NumberServicesTests
{
	public class NumberServiceTests
	{
		[Theory]
		[InlineData(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
		private void SumOfIntegerArrayLessThanOneMillion(long[] integerToSum)
		{
			INumberService number = new NumberService();
			Assert.Equal(45, number.Sum(integerToSum));
		}

		[Theory]
		[MemberData(nameof(BuildOneMillionArray))]
		private void SumOfIntegerArrayUpToOneMillion(long[] integerToSum)
		{
			INumberService number = new NumberService();
			Assert.Equal(499999500000, number.Sum(integerToSum));
		}

		[Theory]
		[InlineData(new long[] { })]
		private void SumOfEmptyArray(long[] integerToSum)
		{
			INumberService number = new NumberService();
			Assert.Equal(0, number.Sum(integerToSum));
		}

		[Theory]
		[InlineData("4 + 5 + 6 + 7 + 8")]
		private void Sum4NumberExpression(string mathExpression)
		{
			INumberService number = new NumberService();
			Assert.Equal(30, number.ProcessMathExpression(mathExpression));
		}

		[Theory]
		[InlineData("15 * 5 + 5 / 2")]
		private void EvaluateComplexMathExpression(string mathExpression)
		{
			INumberService number = new NumberService();
			Assert.Equal(77.5, number.ProcessMathExpression(mathExpression));
		}

        [Theory]
        [InlineData("5 + 5 / 0")]
        private void EvaluateDivisonByZero(string mathExpression)
        {
            INumberService number = new NumberService();
            Assert.Throws<DivideByZeroException>(() => number.ProcessMathExpression(mathExpression));
        }

        [Theory]
        [InlineData("5 +5 /2")]
        private void EvaluateWrongExpressionFormat(string mathExpression)
        {
            INumberService number = new NumberService();
            Assert.Throws<FormatException>(() => number.ProcessMathExpression(mathExpression));
        }

        #region Extension

        /// <summary>
        /// Gera um milhão de números inteiros.
        /// </summary>
        /// <returns></returns>
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
