using BloodDonation.Application.Handlers.Donors;
using BloodDonation.Application.Validators.Donors;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddFluentValidation()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddFluentValidation(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateDonorValidator>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateDonorHandler>());

            return services;
        }

    }
}
