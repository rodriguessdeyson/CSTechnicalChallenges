using CSTechnicalChallenges.Domain;
using CSTechnicalChallenges.Domain.Interfaces;

namespace CSTechnicalChallenges.Services
{
	public class NumberService : INumberService
	{
		public NumberService()
		{
			
		}

		public float ProcessMathExpression(string mathExpression)
		{
			throw new NotImplementedException();
		}

		public long Sum(long[] numbersToSum)
		{
			return numbersToSum.Sum();
		}

		public string ToWords(long numberToWord)
		{
			throw new NotImplementedException();
		}
	}
}
