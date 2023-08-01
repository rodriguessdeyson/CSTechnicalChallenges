using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSTechnicalChallenges.Infra.IoC
{
	public class ServiceInjector
	{
		/// <summary>
		/// Registra as dependências.
		/// </summary>
		/// <param name="services">Conjunto de serviços.</param>
		public static void RegisterServices(IServiceCollection services)
		{
			services.AddSingleton<INumberService, NumberService>();
			services.AddSingleton<IListManager, ListManagerService>();
		}
	}
}
