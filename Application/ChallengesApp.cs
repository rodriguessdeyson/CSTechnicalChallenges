using CSTechnicalChallenges.Domain.Interfaces;

namespace CSTechnicalChallenges.Application
{
	public class ChallengesApp
	{
		private readonly INumberService NumberService;

		public ChallengesApp(INumberService numberService)
		{
			NumberService = numberService;
		}

		public void Run()
		{
			Console.WriteLine("Desafio 1:");
			FirstChallenge();

            Console.WriteLine("Desafio 2:");
            SecondChallenge();

            Console.WriteLine("Desafio 3:");
            ThirdChallenge();
		}

        private void FirstChallenge()
        {
			long testNumber = 458;
            Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");

            testNumber = 658;
            Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");

            testNumber = 9999999;
            Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");
        }

        private void SecondChallenge()
		{
			long[] nums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
			Console.WriteLine($"A soma de {nums.Length} números inteiros é: {NumberService.Sum(nums)}");

			nums = Enumerable.Range(0, 1000000).Select(el => (long)el).ToArray();
            Console.WriteLine($"A soma de {nums.Length} números inteiros é: {NumberService.Sum(nums)}");
        }

		private void ThirdChallenge()
		{
			string mathExpression = string.Empty;
			try
			{
				mathExpression = "2 + 3 * 5";

                long resolution = NumberService.ProcessMathExpression(mathExpression);
                Console.WriteLine($"A solução da expressão {mathExpression} é: {resolution}");

				mathExpression = "2 + 3 / 0";

                resolution = NumberService.ProcessMathExpression(mathExpression);
                Console.WriteLine($"A solução da expressão {mathExpression} é: {resolution}");
            }
			catch (Exception exception)
			{
				Console.WriteLine($"A solução da expressão {mathExpression} retornou um erro: {exception.Message}");
			}
		}
	}
}
