using CSTechnicalChallenges.Domain;
using CSTechnicalChallenges.Domain.Helper;
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
            List<string> postfixTokens = ShuntingYard.ConvertToPostfix(mathExpression);
            return ShuntingYard.CalculatePostfix(postfixTokens);
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
