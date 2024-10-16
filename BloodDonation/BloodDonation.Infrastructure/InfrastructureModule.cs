using BloodDonation.Infrastructure.ExternalApi.CepApi;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructute(this IServiceCollection services)
        {
            services.AddSevices();
            return services;
        }

        private static IServiceCollection AddSevices(this IServiceCollection services) 
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICepRepository, CepRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            return services;
        }

        private static IServiceCollection AddRefit(this IServiceCollection services) 
        {
            //services.AddRefit<IApiService>()
            //    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.exemplo.com"));

            /*
             builder.Services.AddRefitClient<IApiService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.exemplo.com"));
             */

            return services;
        }

    }
}
