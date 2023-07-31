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
            long[] nums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Console.Write($"A soma dos inteiros é: {NumberService.Sum(nums)}");


        }
    }
}
