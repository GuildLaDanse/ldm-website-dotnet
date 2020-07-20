using Auth0.Implementation;
using LaDanse.Common;
using LaDanse.Common.Configuration;
using LaDanse.External.BattleNet.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            services.AddBattleNetApi();
            services.AddAuth0Api();

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<ILaDanseConfiguration, LaDanseConfiguration>();
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();

            return services;
        }
    }
}