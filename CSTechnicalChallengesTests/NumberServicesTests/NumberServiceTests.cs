using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Services;
using Xunit;

namespace CSTechnicalChallenges.ServicesTests
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
