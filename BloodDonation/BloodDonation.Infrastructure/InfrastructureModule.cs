using BloodDonation.Core.Repositories;
using BloodDonation.Core.Services;
using BloodDonation.Infrastructure.Auth;
using BloodDonation.Infrastructure.ExternalApi.CepApi;
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICepRepository, CepRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
