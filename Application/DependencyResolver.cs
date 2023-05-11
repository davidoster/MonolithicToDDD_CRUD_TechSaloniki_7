using Application.ServiceInterface;
using Application.Services;
using Application.MyUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;

namespace Application {
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add all application-specific services to the service collection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITrainerService, TrainerService>();

            return services;
        }
    }
}