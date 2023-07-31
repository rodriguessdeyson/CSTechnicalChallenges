using CSTechnicalChallenges.Application;
using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSTechnicalChallenges.Infra.IoC
{
    public class ServiceInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<INumberService, NumberService>();
        }
    }
}
