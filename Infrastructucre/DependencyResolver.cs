
using Infrastructucre.RepoImplementations;
using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;

namespace Infrastructucre
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            // Add all application-specific services to the service collection
            services.AddScoped<ITrainerRepository,TrainerRepository>();
            //services.AddScoped<ISkillsRepository>(provider => provider.GetRequiredService<SkillRepository>());
            services.AddScoped<ISkillsRepository, SkillRepository>();

            return services;


        }
    }

}