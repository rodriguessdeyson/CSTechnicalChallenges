using CSTechnicalChallenges.Application;
using CSTechnicalChallenges.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CSTechnicalChallenges
{
	public class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection services = new ServiceCollection();
			ServiceInjector.RegisterServices(services);

			services?.AddSingleton<ChallengesApp>()
                .BuildServiceProvider()
                .GetService<ChallengesApp>()
				.Run();

			Console.ReadLine();
        }
	}
}